# Library App

## Description
Library App is a .NET Core console application that provides a library management system. It allows librarians to manage books, patrons, and loans, including functionalities such as borrowing books, returning books, extending loans, and renewing patron memberships.

## Project Structure
* GuidedProjectApp.sln
* AccelerateDevGitHubCopilot/
  * src/
    * Library.ApplicationCore/
      * Entities/
        * Author.cs
        * Book.cs
        * BookItem.cs
        * Loan.cs
        * Patron.cs
      * Enums/
        * EnumHelper.cs
        * LoanExtensionStatus.cs
        * LoanReturnStatus.cs
        * MembershipRenewalStatus.cs
      * Interfaces/
        * ILoanRepository.cs
        * ILoanService.cs
        * IPatronRepository.cs
        * IPatronService.cs
      * Services/
        * LoanService.cs
        * PatronService.cs
    * Library.Console/
      * Json/
        * Authors.json
        * BookItems.json
        * Books.json
        * Loans.json
        * Patrons.json
      * appSettings.json
      * CommonActions.cs
      * ConsoleApp.cs
      * ConsoleState.cs
      * Program.cs
    * Library.Infrastructure/
      * Data/
        * JsonData.cs
        * JsonLoanRepository.cs
        * JsonPatronRepository.cs
  * tests/
    * UnitTests/
      * ApplicationCore/
        * LoanService/
          * ExtendLoan.cs
          * ReturnLoan.cs
        * PatronService/
          * RenewMembership.cs
      * LoanFactory.cs
      * PatronFactory.cs

## Key Classes and Interfaces

### Entities
- **Author**: Represents an author of books in the library
- **Book**: Represents a book title in the library
- **BookItem**: Represents a specific copy of a book that can be borrowed
- **Loan**: Represents a loan transaction between a patron and a book item
- **Patron**: Represents a library member who can borrow books

### Services
- **LoanService**: Handles loan operations like borrowing, returning, and extending loans
- **PatronService**: Handles patron operations like membership renewal

### Interfaces
- **ILoanRepository**: Interface for accessing loan data
- **ILoanService**: Interface defining loan management operations
- **IPatronRepository**: Interface for accessing patron data
- **IPatronService**: Interface defining patron management operations

## Usage
The application can be run from the command line:

```bash
cd AccelerateDevGitHubCopilot/src/Library.Console
dotnet run
```

Once running, the console application provides an interactive menu for managing library operations.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
