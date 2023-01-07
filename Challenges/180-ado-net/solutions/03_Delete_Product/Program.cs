using System.Data;
using System.Data.SqlClient;

internal class Program
{
    private static string _CONNECTIONSTRING =
        @"Server=tcp:sql-kessler-training.database.windows.net,1433;Database=AdventureWorksLT2019;User Id=admin-user;Password=<PW>;";

    static void Main(string[] args)
    {
        Console.WriteLine("Willkommen bei Adventure Works! Mit help siehst du deine Möglichkeiten.");
        DetectCommand();
    }

    static void DetectCommand()
    {
        Console.Write("> ");
        var command = Console.ReadLine();

        switch (command.ToLower())
        {
            case "products":
                ListProducts();
                break;
            case "add product":
                AddProduct();
                break;
            case "customers":
                ListCustomers();
                break;
            case { } when command.ToLower().StartsWith("orders"):
                Orders(command);
                break;
            case { } when command.ToLower().StartsWith("remove product"):
                RemoveProduct(command);
                break;
            case "help":
                Help();
                break;
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine($"Unkown command: {command}");
                Help();
                break;
        }
    }

    static void RemoveProduct(string command)
    {
        if (!int.TryParse(command.Substring(command.IndexOf("#") + 1), out int productId))
        {
            Console.WriteLine("Please use valid product id.");
            Help();
        }

        using (SqlConnection connection = new SqlConnection(_CONNECTIONSTRING))
        {
            SqlCommand cm = new SqlCommand(@$"DELETE FROM [SalesLT].[Product] WHERE ProductID ={productId}", connection);
            connection.Open();

            cm.ExecuteNonQuery();
            
            Console.WriteLine("Das Produkt wurde erfolgreich entfernt.");
        }
        
        DetectCommand();
    }

    static void ListProducts()
    {
        Console.WriteLine("Verfügbare Produkte:\n");

        using (SqlConnection connection = new SqlConnection(_CONNECTIONSTRING))
        {
            SqlCommand cm = new SqlCommand(@"SELECT ProductID, Name FROM [SalesLT].[Product] WHERE YEAR(ModifiedDate) = 2023", connection);

            connection.Open();

            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine($"#{sdr["ProductID"]}: {sdr["Name"]}");
            }
        }

        DetectCommand();
    }

    static void AddProduct()
    {
        Console.WriteLine("Für ein neues Produkt benötige ich folgende Informationen:\n");

        Console.WriteLine("Name:");
        var productName = Console.ReadLine() ?? "";

        Console.WriteLine("Nummer:");
        var productNumber = Console.ReadLine() ?? "";

        Console.WriteLine("Preis:");
        var price = Console.ReadLine() ?? "";

        var category = SelectProductCategory();

        using (SqlConnection connection = new SqlConnection(_CONNECTIONSTRING))
        {
            SqlCommand cm = new SqlCommand(@"INSERT INTO [SalesLT].[Product] (Name, ProductNumber, StandardCost, ListPrice, ProductCategoryID, SellStartDate) 
                VALUES (@Name, @Number, @Price, @Price, @Category, GETDATE())", connection);

            cm.Parameters.AddWithValue("@Name", productName);
            cm.Parameters.AddWithValue("@Number", productNumber);
            cm.Parameters.AddWithValue("@Price", price);
            cm.Parameters.AddWithValue("@Category", category);

            connection.Open();

            cm.ExecuteNonQuery();

            Console.WriteLine($"Das Produkt '{productName}' wurde erfolgreich angelegt.");
        }

        DetectCommand();
    }

    static int SelectProductCategory()
    {
        Console.WriteLine("Wähle eine Produktkategorie (Nummer) aus:");

        using (SqlConnection connection = new SqlConnection(_CONNECTIONSTRING))
        {
            SqlCommand cm = new SqlCommand("SELECT ProductCategoryID, ProductCategoryName FROM dbo.ufnGetAllCategories()", connection);
            connection.Open();

            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine($"#{sdr["ProductCategoryID"]}: {sdr["ProductCategoryName"]}");
            }
        }

        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Das war keine gültige Eingabe. Bitte versuche es nochmals.");
            return SelectProductCategory();
        }
    }

    static void ListCustomers()
    {
        using (SqlConnection connection = new SqlConnection(_CONNECTIONSTRING))
        {
            SqlCommand cm = new SqlCommand(@"SELECT 
                    c.CustomerID,
                    FirstName,
                    LastName,
                    COUNT(sh.SalesOrderID) AS OrderCount
                FROM [SalesLT].[Customer] AS c 
                INNER JOIN [SalesLT].[SalesOrderHeader] AS sh 
                ON c.CustomerID = sh.CustomerID
                GROUP BY c.CustomerID, c.FirstName, c.LastName
                ORDER BY OrderCount DESC", connection);

            connection.Open();

            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine($"#{sdr["CustomerID"]}: {sdr["FirstName"]} {sdr["LastName"]} (Bestellungen: {sdr["OrderCount"]})");
            }
        }

        DetectCommand();
    }

    static void Orders(string command)
    {
        if (!int.TryParse(command.Substring(command.IndexOf("#") + 1), out int customerId))
        {
            Console.WriteLine("Please use valid customer id.");
            Help();
        }

        using (SqlConnection connection = new SqlConnection(_CONNECTIONSTRING))
        {
            SqlCommand cm = new SqlCommand(@$"SELECT  
                    sh.SalesOrderID,
                    sh.OrderDate,
                    sh.SalesOrderNumber,
                    sh.TotalDue,
                    a.AddressLine1,
                    a.City,
                    a.PostalCode
                FROM [SalesLT].[SalesOrderHeader] AS sh
                INNER JOIN [SalesLT].Address AS a
                ON sh.ShipToAddressID = a.AddressID
                WHERE sh.CustomerID = {customerId}", connection);

            connection.Open();

            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine($"Bestellung: #{sdr["SalesOrderNumber"]} vom {sdr["OrderDate"]} über ${sdr["TotalDue"]} an:\n");
                Console.WriteLine($"{sdr["AddressLine1"]}");
                Console.WriteLine($"{sdr["PostalCode"]} {sdr["City"]}\n");

                Console.WriteLine("Mit den folgenden Produkten:");

                using (SqlConnection connection2 = new SqlConnection(_CONNECTIONSTRING))
                {
                    SqlDataAdapter da = new SqlDataAdapter(@$"SELECT
                        sd.OrderQty,
                        sd.UnitPrice,
                        p.Name
                    FROM [SalesLT].[SalesOrderDetail] as sd
                    JOIN [SalesLT].[Product] as p
                    ON sd.ProductID = p.ProductID
                    WHERE sd.SalesOrderID = {sdr["SalesOrderID"]}", connection2);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["OrderQty"]}x {row["Name"]} für ${row["UnitPrice"]}");
                    }
                }
            }
        }

        DetectCommand();
    }

    static void Help()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("     customers                       List all customers");
        Console.WriteLine("     products                        List all products");
        Console.WriteLine("     orders #[customerId]            List all orders for a customer");
        Console.WriteLine("     add product                     Add a new product");
        Console.WriteLine("     remove product #[productId]     Add a new product");
        Console.WriteLine("     help                            Shows all possible commands");
        Console.WriteLine("     exit                            Exit the application");


        DetectCommand();
    }
}