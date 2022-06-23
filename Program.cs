using Cab_Invoice_Generator;

Console.WriteLine("\t\t Welcome to Cab Invoice Generator Program ");
Console.Write("\nPlease Provide the distance travelled (in km) : ");
double distance = Convert.ToDouble(Console.ReadLine());
Console.Write("\nPlease Provide the time taken for the trip (in minutes) : ");
int time = Convert.ToInt32(Console.ReadLine());

CabInvoice invoiceGenerator = new CabInvoice();
Console.WriteLine("\nThe cost of the trip is : " + invoiceGenerator.CalculateFare(distance, time));
