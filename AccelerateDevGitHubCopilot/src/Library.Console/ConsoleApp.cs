using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.ApplicationCore.Enums;
using Library.Console;
using Newtonsoft.Json;

public class ConsoleApp
{
    ConsoleState _currentState = ConsoleState.PatronSearch;

    List<Patron> matchingPatrons = new List<Patron>();

    Patron? selectedPatronDetails = null;
    Loan selectedLoanDetails = null!;

    IPatronRepository _patronRepository;
    ILoanRepository _loanRepository;
    ILoanService _loanService;
    IPatronService _patronService;

    public ConsoleApp(ILoanService loanService, IPatronService patronService, IPatronRepository patronRepository, ILoanRepository loanRepository)
    {
        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
        _loanService = loanService;
        _patronService = patronService;
    }

    public async Task Run()
    {
        while (true)
        {
            switch (_currentState)
            {
                case ConsoleState.PatronSearch:
                    _currentState = await PatronSearch();
                    break;
                case ConsoleState.PatronSearchResults:
                    _currentState = await PatronSearchResults();
                    break;
                case ConsoleState.PatronDetails:
                    _currentState = await PatronDetails();
                    break;
                case ConsoleState.LoanDetails:
                    _currentState = await LoanDetails();
                    break;
            }
        }
    }

    async Task<ConsoleState> PatronSearch()
    {
        string searchInput = ReadPatronName();

        matchingPatrons = await _patronRepository.SearchPatrons(searchInput);

        // Guard-style clauses for edge cases
        if (matchingPatrons.Count > 20)
        {
            Console.WriteLine("More than 20 patrons satisfy the search, please provide more specific input...");
            return ConsoleState.PatronSearch;
        }
        else if (matchingPatrons.Count == 0)
        {
            Console.WriteLine("No matching patrons found.");
            return ConsoleState.PatronSearch;
        }

        Console.WriteLine("Matching Patrons:");
        PrintPatronsList(matchingPatrons);
        return ConsoleState.PatronSearchResults;
    }

    static string ReadPatronName()
    {
        string? searchInput = null;
        while (String.IsNullOrWhiteSpace(searchInput))
        {
            Console.Write("Enter a string to search for patrons by name: ");

            searchInput = Console.ReadLine();
        }
        return searchInput;
    }

    static void PrintPatronsList(List<Patron> matchingPatrons)
    {
        int patronNumber = 1;
        foreach (Patron patron in matchingPatrons)
        {
            Console.WriteLine($"{patronNumber}) {patron.Name}");
            patronNumber++;
        }
    }

    async Task<ConsoleState> PatronSearchResults()
    {
        CommonActions options = CommonActions.Select | CommonActions.SearchPatrons | CommonActions.Quit;
        CommonActions action = ReadInputOptions(options, out int selectedPatronNumber);
        if (action == CommonActions.Select)
        {
            if (selectedPatronNumber >= 1 && selectedPatronNumber <= matchingPatrons.Count)
            {
                var selectedPatron = matchingPatron
