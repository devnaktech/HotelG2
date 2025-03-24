// using Microsoft.AspNetCore.Mvc;
// using Midterm.Models;
// using Midterm.Services; // If you have any services for handling reservations

// public class FrontDeskController : Controller
// {
//     private readonly IReservationService _reservationService; // A service to fetch reservations

//     public FrontDeskController(IReservationService reservationService)
//     {
//         _reservationService = reservationService;
//     }

//     // Action to load the Front Desk page with current reservations
//     public IActionResult Index()
//     {
//         var reservations = _reservationService.GetUpcomingReservations(); // Example service call
//         return View(reservations);
//     }

//     // Action to handle check-in
//     public IActionResult CheckIn(int id)
//     {
//         _reservationService.CheckInReservation(id); // Example service call for checking in
//         return RedirectToAction("Index");
//     }

//     // Action to handle check-out
//     public IActionResult CheckOut(int id)
//     {
//         _reservationService.CheckOutReservation(id); // Example service call for checking out
//         return RedirectToAction("Index");
//     }
// }
