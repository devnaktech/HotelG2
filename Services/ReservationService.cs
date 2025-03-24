// using Microsoft.EntityFrameworkCore;
// using Midterm.Data;
// using Midterm.Models;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Midterm.Services
// {
//     public class ReservationService : IReservationService
//     {
//         private readonly AppDbContext _context;

//         public ReservationService(AppDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
//         {
//             return await _context.Reservations
//                 .Include(r => r.Customer)
//                 .Include(r => r.Room)
//                 .ToListAsync();
//         }

//         public async Task<Reservation> GetReservationByIdAsync(int id)
//         {
//             return await _context.Reservations
//                 .Include(r => r.Customer)
//                 .Include(r => r.Room)
//                 .FirstOrDefaultAsync(r => r.ReservationId == id);
//         }

//         public async Task CreateReservationAsync(Reservation reservation)
//         {
//             if (reservation == null)
//                 throw new ArgumentNullException(nameof(reservation));

//             _context.Reservations.Add(reservation);
//             await _context.SaveChangesAsync();
//         }

//         public async Task UpdateReservationAsync(Reservation reservation)
//         {
//             if (reservation == null)
//                 throw new ArgumentNullException(nameof(reservation));

//             _context.Reservations.Update(reservation);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteReservationAsync(int id)
//         {
//             var reservation = await _context.Reservations.FindAsync(id);
//             if (reservation == null)
//                 throw new KeyNotFoundException("Reservation not found");

//             _context.Reservations.Remove(reservation);
//             await _context.SaveChangesAsync();
//         }

//         // Implement GetUpcomingReservations
//         public async Task<IEnumerable<Reservation>> GetUpcomingReservationsAsync()
//         {
//             return await _context.Reservations
//                 .Where(r => r.CheckInDate > DateTime.Now)
//                 .Include(r => r.Customer)
//                 .Include(r => r.Room)
//                 .ToListAsync();
//         }

//         // Implement CheckInReservation
//         public async Task CheckInReservationAsync(int reservationId)
//         {
//             var reservation = await _context.Reservations
//                 .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
//             if (reservation == null)
//                 throw new KeyNotFoundException("Reservation not found");

//             reservation.Status = "Checked In"; // Assuming there's a Status property
//             await _context.SaveChangesAsync();
//         }

//         // Implement CheckOutReservation
//         public async Task CheckOutReservationAsync(int reservationId)
//         {
//             var reservation = await _context.Reservations
//                 .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
//             if (reservation == null)
//                 throw new KeyNotFoundException("Reservation not found");

//             reservation.Status = "Checked Out"; // Assuming there's a Status property
//             await _context.SaveChangesAsync();
//         }
//     }
// }
