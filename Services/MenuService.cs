using Arendehanteringssystem.Models;
using Arendehanteringssystem.Models.Entities;
using Status = Arendehanteringssystem.Models.Entities.Status;

namespace Arendehanteringssystem.Services;

public class MenuService
{

    //klar
    public static async Task CreateUserAndErrandAsync()
    {

        ErrandModel errand = new();
        CustomerModel customer = new();

        Console.WriteLine("Skapa en kontakt");

        Console.Write("Ange förnamn: ");
        customer.FirstName = Console.ReadLine() ?? "";

        Console.Write("Ange efternamn: ");
        customer.LastName = Console.ReadLine() ?? "";

        Console.Write("Ange e-postadress: ");
        customer.Email = Console.ReadLine() ?? "";

        Console.Write("Ange telefonnummer: ");
        customer.PhoneNumber = Console.ReadLine() ?? "";

        Console.WriteLine("Skapa ett nytt ärende");

        Console.WriteLine("Beskriv ditt ärende: ");
        errand.ErrandDescription = Console.ReadLine() ?? "";

        if (customer != null && errand != null)
            await CustomerService.SaveUserAndErrandAsync(customer, errand);
    }

    //klar
    public static void CreateErrand()
    {

        Console.Clear();

        Console.Write("Ange e-postadress: ");
        var email = Console.ReadLine();

        if (email == null)
        {
            Console.WriteLine($"Ingen användare med {email} hittades.");
        }
        else
        {

            CustomerEntity customer = CustomerService.GetUserByEmail(email);

            ErrandEntity errand = new();

            Console.Write("Beskriv ditt ärende: ");

            
            errand.ErrandDescription = Console.ReadLine() ?? "";
           

            ErrandService.SaveErrand(customer, errand);
        }
    }

    //klar
    public static async Task GetAllErrandsAsync()
    {

        List<ErrandEntity> errands = (List<ErrandEntity>)await ErrandService.GetAllAsync();

        Console.Clear();

        foreach (ErrandEntity errand in errands)
        {
            Console.WriteLine($"Ärendenummer: {errand.Id}");
            Console.WriteLine($"Beskrivning av ärende: {errand.ErrandDescription}");
            Console.WriteLine($"Utfärdat: {errand.TimeStamp}");
            Console.WriteLine($"Status: {errand.StatusAndComment.Status}");
            Console.WriteLine($"Kommentar: {errand.StatusAndComment.Comment}");
            Console.WriteLine($"Utfärdat av ansvarig: {errand.StatusAndComment.TimeStamp}");
            Console.WriteLine(" ");
        }
    }

    //klar
    public static async Task GetSpecificErrand()
    {

        CustomerEntity customer = new();

        Console.Write("Ange e-postadress: ");
        var email = Console.ReadLine();

        if (email == null)
        {
            Console.WriteLine("Inget ärende hittades");
        }
        else
        {
            customer.Errands = await ErrandService.GetErrandsByEmailAsync(email);

            Console.Clear();

            foreach (ErrandEntity errand in customer.Errands)
            {
                Console.WriteLine($"Ärendenummer: {errand.Id}");
                Console.WriteLine($"Beskrivning av ärende: {errand.ErrandDescription}");
                Console.WriteLine($"Utfärdat av kund: {errand.TimeStamp}");
                Console.WriteLine($"Status: {errand.StatusAndComment.Status}");
                Console.WriteLine($"Kommentar: {errand.StatusAndComment.Comment}");
                Console.WriteLine($"Utfärdat av ansvarig: {errand.StatusAndComment.TimeStamp}");
                Console.WriteLine(" ");
            }
        }
    }

    //ej klar
    public static void UpdateStatusAndComment()
    {

        Console.Write("Ange kundens e-postadress: ");
        var email = Console.ReadLine() ?? "";

        List<ErrandEntity> errands = ErrandService.GetErrandsByEmail(email);

        foreach (ErrandEntity errand in errands)
        {
            Console.WriteLine($"Ärendenummer: {errand.Id}");
            Console.WriteLine($"Beskrivning av ärende: {errand.ErrandDescription}");
            Console.WriteLine($"Utfärdat av kund: {errand.TimeStamp}");
            Console.WriteLine($"Status: {errand.StatusAndComment.Status}");
            Console.WriteLine($"Kommentar: {errand.StatusAndComment.Comment}");
            Console.WriteLine($"Utfärdat av ansvarig: {errand.StatusAndComment.TimeStamp}");
            Console.WriteLine(" ");
            Console.Write($"Uppdatera kommentar på detta ärende: ");
            errand.StatusAndComment.Comment = Console.ReadLine() ?? "";

            Console.WriteLine("Ange status på detta ärende: Ej påbörjad (1), Pågående (2) eller Avslutad (3).");
            var option = Console.ReadLine();

            if (option != null)
            {
                switch (option)
                {
                    case "1": errand.StatusAndComment.Status = Status.NotStarted; break;
                    case "2": errand.StatusAndComment.Status = Status.Ongoing; break;
                    case "3": errand.StatusAndComment.Status = Status.Finished; break;
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt svar, ärendets status är oförändrad.");
            }

            StatusAndCommentService.SaveUpdatedStatusAndComment(errand);
        }
    }

    public static async void MainMenu()

    {
        Console.WriteLine("Välkommen till supporten");
        Console.WriteLine("1. Skapa användare och ärende");
        Console.WriteLine("2. Skapa ärende med befintlig användare");
        Console.WriteLine("3. Visa alla ärenden");
        Console.WriteLine("4. Visa en specifik kunds ärende/ärenden");
        Console.WriteLine("5. Uppdatera status eller kommentar på ett ärende");
        Console.WriteLine("Välj ett av alternativen ovan:");
        var option = Console.ReadLine();

        Console.Clear();

        switch (option)
        {
            case "1": await CreateUserAndErrandAsync(); break;
            case "2": CreateErrand(); break;
            case "3": await GetAllErrandsAsync(); break;
            case "4": await GetSpecificErrand(); break;
            case "5": UpdateStatusAndComment(); break;
        }

    }


}
