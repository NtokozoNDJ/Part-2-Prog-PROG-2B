using System.Windows;
using Part_2_Prog.Services;
using Part_2_Prog.Models;
using Microsoft.Win32;

namespace Part_2_Prog.Views
{
    public partial class MainWindow : Window
    {
        private readonly DataService _dataService;
        private string selectedFilePath;

        public MainWindow()
        {
            InitializeComponent();
            _dataService = new DataService();
            LoadClaimStatuses(null, null);  // Automatically load claim statuses when the window opens
            LoadPendingClaims(null, null);  // Automatically load pending claims when the window opens
        }

        // Submit Claim Button Click Handler
        private void SubmitClaimButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(HoursWorkedTextBox.Text, out decimal hoursWorked) && decimal.TryParse(HourlyRateTextBox.Text, out decimal hourlyRate))
            {
                _dataService.AddClaim(1, hoursWorked, hourlyRate, selectedFilePath);  // Assuming user ID 1 is logged in
                MessageBox.Show("Claim submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for Hours Worked and Hourly Rate.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Browse for Supporting Document
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Document files (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
                FileNameTextBlock.Text = System.IO.Path.GetFileName(selectedFilePath);
            }
        }

        // Load Lecturer's Claims (Show in Claim Status Tab)
        private void LoadClaimStatuses(object sender, RoutedEventArgs e)
        {
            ClaimStatusListView.ItemsSource = _dataService.GetLecturerClaims(1);  // Assuming user ID 1 is logged in
        }

        // Load Pending Claims for Coordinators (Show in Approve Claims Tab)
        private void LoadPendingClaims(object sender, RoutedEventArgs e)
        {
            PendingClaimsListView.ItemsSource = _dataService.GetPendingClaims();
        }

        // Approve Selected Claim
        private void ApproveClaim_Click(object sender, RoutedEventArgs e)
        {
            if (PendingClaimsListView.SelectedItem is Part_2_Prog.Models.Claim selectedClaim)
            {
                _dataService.ApproveClaim(selectedClaim.ClaimID, 2);  // Assuming coordinator ID 2 is logged in
                MessageBox.Show("Claim approved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadPendingClaims(null, null);  // Refresh the pending claims list
            }
        }

        // Reject Selected Claim
        private void RejectClaim_Click(object sender, RoutedEventArgs e)
        {
            if (PendingClaimsListView.SelectedItem is Part_2_Prog.Models.Claim selectedClaim)
            {
                _dataService.RejectClaim(selectedClaim.ClaimID, 2);  
                MessageBox.Show("Claim rejected.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadPendingClaims(null, null);  // Refresh the pending claims list
            }
        }

        // Clear the form after submission
        private void ClearForm()
        {
            HoursWorkedTextBox.Clear();
            HourlyRateTextBox.Clear();
            FileNameTextBlock.Text = "No file selected";
            selectedFilePath = null;
        }
    }
}
