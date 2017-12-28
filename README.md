# WPFProjectCheatham
Showcasing WPF Skills

WPF Programming Project/Test

1.	Create a C# WPF project in Visual Studio.  Name the project WPFProjectSMITH (where SMITH is substituted with your last name).
2.	Add a Label, a Textbox, and a Button to the window.
a.	The Label should print information directing the user to enter a number between 1 and 5 into the textbox
b.	The textbox should be presented to the right of the label.
c.	The button should be below the textbox and should have the text ‘Search’ as the default content.
3.	If someone enters a value outside the range of 1 and 5, a new window should appear telling the user to enter a number in the specified range.
4.	If someone enters a non-number into the field, a new window should appear telling the user that the input needs to be a number in the range of 1 to 5.
5.	If the value of the data is between 1 and 5 when the ‘Search’ button is pressed, the number is passed as a portion of the ReST API GET call to the following address:
http://www.thomas-bayer.com/sqlrest/CUSTOMER/X 
(where X is the number entered in the textbox).  For example, if the number 1 is entered and the search button clicked, the application would perform a GET to:
http://www.thomas-bayer.com/sqlrest/CUSTOMER/1
6.	The application should take the data response and perform the following changes to the original window:
a.	Hide the Textbox and Button
b.	Change the text in the Label to “Here is the customer #X” where X was the number entered in the textbox.
c.	Present the Customer First Name, Last Name, and City in the window  
7.	The deliverable for the project should be the full source code of the project in a zipped file.  The project should be emailed to the manager and the developer should send a follow-up email to confirm receipt of the project email (in the event the attachment was blocked).
