Contract Monthly Claim System (CMCS)
Project Overview
The Contract Monthly Claim System, CMCS, is a WPF application intended for claim submissions by lecturers and approval or rejection by coordinators or managers. It has a slick, futuristic look with dark mode; thus, it is simple and easy for its end-users.

Features
Submit Claim: Lecturers can submit their claims for hours worked and upload supporting documents.
Approve Claims: Coordinators can see the pending claims of all and managers may approve or reject the claim.
Claim Status: Lecturers can see the status of their submitted claim: pending, approved, or rejected.
UI Layout & Design
The dark mode theme-Black with accents of Blue & White gives this interface a sleek & modern look. Spacey & futuristic, further button styling is continued with emphasis on readability & clarity.

Tabbing Order
Submit Claim:
A form for the lecturers to fill in their hours worked, hourly rate, and upload supportive documents.
Approve Claims:
List of pending claims for coordinators or managers to act upon, with options to approve or reject selected claim.
Claim Status:
List of the lecturer's submitted claim, showing number of hours worked, total amount, and status.
Styling Choices
Dark Mode Theme: A black background (#0C0C0C) is used throughout the application to give it that sleek, modern look.
Blue Accents: A blue color, #1E90FF, used for headers, buttons, and any other normally interactive elements.
White Text: Most of the text is white while headers provide an interesting contrast of blue to the dark background.
Modern Buttons: Most of the buttons would have bold text, white font, with a blue background when performing normal actions and a red background, #FF4500, when performing reject actions to make it clear.
Main Components
1. Submit Claim Tab
This is where the lecturers will input the following information:

Hours Worked
Hourly Rate
Supporting Documents (Optional)
Once submitted, this will store the claim in memory and display a confirmation message.

2. Approve Claims Tab
Via this tab, the coordinator can:

View all Pending Claims.
Accept or Reject claims by highlighting a claim in the list and then clicking the corresponding button.
There is also a refresh button, which enables the coordinator to refresh the latest list of pending claims.

3. Claim Status Tab
This tab displays all the claims submitted by the currently logged-in lecturer. The data shown includes:

Claim ID
Hours Worked
Total Amount
Current Status - Pending, Approved, or Rejected
Lecturers can refresh this list to view the latest status of their claims.

Overview
Main Files
MainWindow.xaml:
This XAML contains all the layout and styling for the application. He has done a fantastic job utilizing a TabControl to switch out the Submit Claim, Approve Claims and Claim Status sections.
MainWindow.xaml.cs:
The code behind the MainWindow.xaml. The code deals with the logic that will be required for submit claim, approve/reject claim and loading for each tab.
Key Methods
SubmitClaimButton_Click: To handle the submission of a claim by the lecturer.
BrowseButton_Click: Opens a file dialog to let the lecturer attach supporting documents.
LoadClaimStatuses: This would load the status of claims made by the currently logged-in lecturer.
LoadPendingClaims: To load and display pending claims, for coordinators/managers.
ApproveClaim_Click and RejectClaim_Click: This would allow coordinators to approve or reject selected claims.
Running the Application
Clone the repository or download the project files.
Open the project in Visual Studio.
Build and run the project.
The application will open a window displaying three main tabs:
Submit Claim
Approve Claims
Claim Status
Dependencies
.NET Framework - or higher, whatever the environment requires
Visual Studio 2019 or later if you want to continue working in WPF
Future Improvements
Add login for the user to distinguish the lecturer, coordinator, and manager.
Utilize some form of database so data could remain persisted instead of memory bound.
More animations/transitions to generate a cooler, futuristic look and feel
Acknowledgments
WPF: This project uses Windows Presentation Foundation for developing a desktop-based GUI application.
Futuristic UI Inspiration: It has used a color palette and layout designed to make the experience as clean, modern, and even futuristic as possible for the user.
