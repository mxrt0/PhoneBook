using PhoneBook.Utils.Enums;

namespace PhoneBook.Utils
{
    public static class Messages
    {
        public static readonly string MainMenuMessage = "\nContacts Main Menu\n\n- - - - - - - - - - - - - -";

        public static readonly string PressAnyKeyToContinueMessage = "\nPress any key to continue...\n";

        public static readonly string ReturnToMainMenuMessage = "\nType 0 to return to the Main Menu:\n";

        public static readonly string InvalidInputMessage = $"\nInvalid input. Please enter a number between 0 and {Enum.GetValues<MenuOption>().Length - 1}!\n";

        public static readonly string ExitMessage = "\nGoodbye!...\n";

        // Add contact

        public static readonly string AddContactNameMessage = "\nEnter the name of your new contact:\n";

        public static readonly string InvalidContactNameMessage = "\nInvalid name. Please enter a non-empty string containing at least 1 letter!\n";

        public static readonly string AddContactEmailMessage = "\nEnter the e-mail of your new contact:\n";

        public static readonly string InvalidContactEmailMessage = "\nInvalid e-mail. Left part must have at least 1 letter, there should a domain section (e.g. xyz.com) and an @ separating the two parts!\n";

        public static readonly string AddContactPhoneMessage = "\nEnter the phone number of your new contact (max length 20):\n";

        public static readonly string InvalidContactPhoneMessage = "\nInvalid phone number. Must be at most 20 characters, start with an optional '+', contain only digits, and may include dashes '-' between digits.\n";

        public static readonly string SuccessfullyAddedContactMessage = "\nSuccessfully added new contact!\n";

        // Delete
        public static readonly string DeleteContactIdMessage = "\nEnter the ID of the contact you wish to delete:\n";

        public static readonly string ContactDoesNotExistMessage = "\nContact with this ID doesn't exist. Try again!\n";

        public static readonly string InvalidIdMessage = "\nInvalid ID. Please enter a positive integer!\n";

        public static readonly string SuccessfullyDeletedContactMessage = "\nSuccessfully deleted contact with ID {0}!\n";

    }
}
