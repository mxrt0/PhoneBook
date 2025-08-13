using PhoneBook.DBContext;
using PhoneBook.Entities;
using PhoneBook.Utils;
using PhoneBook.Utils.Enums;

namespace PhoneBook.Controllers
{
    public class ContactsController
    {
        private ContactsDbContext _dbContext;

        public ContactsController(ContactsDbContext dbContext)
        {
            _dbContext = dbContext;
            CreateDb();
            MainMenu();
        }

        public void CreateDb() => _dbContext.Database.EnsureCreated();

        private void MainMenu()
        {
            Console.WriteLine(Messages.MainMenuMessage);
            UIHelper.DisplayOptions();

            string? userInput = Console.ReadLine();

            while (!Validator.IsUserInputValid(userInput))
            {
                Console.WriteLine(Messages.InvalidInputMessage);
                userInput = Console.ReadLine();
            }
            HandleUserInput(Enum.Parse<MenuOption>(userInput!));
        }

        private void HandleUserInput(MenuOption option)
        {
            switch (option)
            {
                case MenuOption.ExitApp:
                    Console.WriteLine(Messages.ExitMessage);
                    Environment.Exit(0);
                    break;
                case MenuOption.AddContact:
                    AddNewContact();
                    break;
                case MenuOption.DeleteContact:
                    DeleteContact();
                    break;
            }
            MainMenu();
        }

        private void DeleteContact()
        {
            Console.Clear();

            Console.WriteLine("\nYour contacts:\n");
            Console.WriteLine(string.Join(Environment.NewLine, _dbContext.Contacts.ToList()));

            Console.WriteLine(Messages.DeleteContactIdMessage);
            Console.WriteLine(Messages.ReturnToMainMenuMessage);

            int contactToDeleteId = GetContactIdInput();

            while (!_dbContext.Contacts.Any(contact => contact.Id == contactToDeleteId))
            {
                Console.WriteLine(Messages.ContactDoesNotExistMessage);
                Console.WriteLine(Messages.ReturnToMainMenuMessage);
                contactToDeleteId = GetContactIdInput();
            }

            _dbContext.Contacts.Remove(_dbContext.Contacts.First(c => c.Id == contactToDeleteId));
            _dbContext.SaveChanges();

            Console.WriteLine(string.Format(Messages.SuccessfullyDeletedContactMessage, contactToDeleteId));
            Console.WriteLine(Messages.PressAnyKeyToContinueMessage);
            Console.ReadKey();
        }

        private void AddNewContact()
        {
            Console.Clear();

            Console.WriteLine(Messages.AddContactNameMessage);
            Console.WriteLine(Messages.ReturnToMainMenuMessage);
            string? nameInput = GetContactNameInput();

            Console.WriteLine(Messages.AddContactEmailMessage);
            Console.WriteLine(Messages.ReturnToMainMenuMessage);
            string? emailInput = GetContactEmailInput();

            Console.WriteLine(Messages.AddContactPhoneMessage);
            Console.WriteLine(Messages.ReturnToMainMenuMessage);
            string? phoneInput = GetContactPhoneInput();

            var newContact = new Contact(nameInput, emailInput, phoneInput);
            _dbContext.Contacts.Add(newContact);
            _dbContext.SaveChanges();

            Console.WriteLine(Messages.SuccessfullyAddedContactMessage);
            Console.WriteLine(Messages.PressAnyKeyToContinueMessage);
            Console.ReadKey();
        }

        private void CheckReturnToMainMenu(string? input)
        {
            if (!string.IsNullOrEmpty(input) && input == "0")
            {
                MainMenu();
            }
        }

        private int GetContactIdInput()
        {
            string? contactToDeleteIdInput = Console.ReadLine();

            int contactToDeleteId = 0;
            while (!int.TryParse(contactToDeleteIdInput, out contactToDeleteId) || contactToDeleteId <= 0)
            {
                Console.WriteLine(Messages.InvalidIdMessage);
                contactToDeleteIdInput = Console.ReadLine();
            }

            return contactToDeleteId;
        }

        private string GetContactNameInput()
        {
            string? nameInput = Console.ReadLine();
            CheckReturnToMainMenu(nameInput);

            while (!Validator.IsContactNameInputValid(nameInput))
            {
                Console.WriteLine(Messages.InvalidContactNameMessage);
                Console.WriteLine(Messages.ReturnToMainMenuMessage);
                nameInput = Console.ReadLine();
                CheckReturnToMainMenu(nameInput);
            }
            return nameInput!;
        }

        private string GetContactEmailInput()
        {
            string? emailInput = Console.ReadLine();
            CheckReturnToMainMenu(emailInput);

            while (!Validator.IsContactEmailInputValid(emailInput))
            {
                Console.WriteLine(Messages.InvalidContactEmailMessage);
                Console.WriteLine(Messages.ReturnToMainMenuMessage);
                emailInput = Console.ReadLine();
                CheckReturnToMainMenu(emailInput);
            }
            return emailInput!;
        }
        private string GetContactPhoneInput()
        {
            string? phoneInput = Console.ReadLine();
            CheckReturnToMainMenu(phoneInput);

            while (!Validator.IsContactPhoneInputValid(phoneInput))
            {
                Console.WriteLine(Messages.InvalidContactPhoneMessage);
                Console.WriteLine(Messages.ReturnToMainMenuMessage);
                phoneInput = Console.ReadLine();
                CheckReturnToMainMenu(phoneInput);
            }
            return phoneInput!;
        }
    }
}
