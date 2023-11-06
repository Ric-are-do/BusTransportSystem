using BusServiceApplication.Data.Models;

namespace BusServiceApplication.Pages.BusRoutComponenet
{

    // create the bus rout information we will use throughout the application 
    //-----------------
    //Afternoon bus trip detao;s 
    public static class BusOneAfternoonTripDetails
    {
 
        public static int BusNumber { get; } = 1;
        public static int BusLimit { get; } = 35;
        public static string BusRouteAAddress { get; } = "Corner of Panorama and Marabou Road";
        public static string BusRouteAPickupTime { get; } = "14:30";
        public static string BusRouteBAddress { get; } = "Corner of Kolgansstraat and Skimmerstraat";
        public static string BusRouteBPickupTime { get; } = "14:40";
        public static bool MorningTrip { get; } = false;
        public static string Area { get; } = "Rooihuiskraal/The Reeds";

    }


    public static class BusTwoAfternoonTripDetails
    {
        public static int BusNumber { get; } = 2;
        public static int BusLimit { get; } = 15;
        public static string BusRouteAAddress { get; } = "Corner of Reddersburg Street and Mafeking Drive";
        public static string BusRouteAPickupTime { get; } = "14:25";
        public static string BusRouteBAddress { get; } = "Corner of Theuns van Niekerkstraat and Roosmarynstraat";
        public static string BusRouteBPickupTime { get; } = "14:30";
        public static bool MorningTrip { get; } = false;
        public static string Area { get; } = "Wierdapark/Amberfield";
    }

    public static class BusThreeAfternoonTripDetails
    {
        public static int BusNumber { get; } = 3;
        public static int BusLimit { get; } = 15;
        public static string BusRouteAAddress { get; } = "Corner of Jasper Drive and Tieroog Street";
        public static string BusRouteAPickupTime { get; } = "14:30";
        public static string BusRouteBAddress { get; } = "Corner of Louise Street and Von Willich Drive";
        public static string BusRouteBPickupTime { get; } = "14:40";
        public static bool MorningTrip { get; } = false;
        public static string Area { get; } = "Centurion";
    }


    //------
    // Morning bus trip information starts here 
    public static class BusOneMorningTripDetails
    {
        public static int BusNumber { get; } = 1;
        public static int BusLimit { get; } = 35;
        public static string BusRouteAAddress { get; } = "Corner of Panorama and Marabou Road";
        public static string BusRouteAPickupTime { get; } = "6:22";
        public static string BusRouteBAddress { get; } = "Corner of Kolgansstraat and Skimmerstraat";
        public static string BusRouteBPickupTime { get; } = "6:30";
        public static bool MorningTrip { get; } = true;
        public static string Area { get; } = "Rooihuiskraal/The Reeds";

    }

    public static class BusTwoMorningTripDetails 
    {
        public static int BusNumber { get; } = 2;
        public static int BusLimit { get; } = 15;
        public static string BusRouteAAddress { get; } = "Corner of Reddersburg Street and Mafeking Drive";
        public static string BusRouteAPickupTime { get; } = "6:25";
        public static string BusRouteBAddress { get; } = "Corner of Theuns van Niekerkstraat and Roosmarynstraat";
        public static string BusRouteBPickupTime { get; } = "6:35";
        public static bool MorningTrip { get; } = true;
        public static string Area { get; } = "Wierdapark/Amberfield";
    }

    public static class BusThreeMorningTripDetails
    {
        public static int BusNumber { get; } = 3;
        public static int BusLimit { get; } = 15;
        public static string BusRouteAAddress { get; } = "Corner of Jasper Drive and Tieroog Street";
        public static string BusRouteAPickupTime { get; } = "6:20";
        public static string BusRouteBAddress { get; } = "Corner of Louise Street and Von Willich Drive";
        public static string BusRouteBPickupTime { get; } = "6:40";
        public static bool MorningTrip { get; } = true;
        public static string Area { get; } = "Centurion";
    }

}
