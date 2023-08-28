using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using FinalAssignment.Models;

namespace FinalAssignment.Data;

public static class SeedData{
    public static void Initialise(IServiceProvider serviceProvider){
        using var context = new RoomBookingContext(serviceProvider.GetService<DbContextOptions<RoomBookingContext>>());

        if(context.Rooms.Any()){
            return;
        }

        context.Rooms.AddRange(
            new Room{
                RoomID = "14.10.31",
                Capacity = 2,
                HasProjector = true
            },
            new Room{
                RoomID = "14.09.15",
                Capacity = 300,
                HasProjector = false
            }
        );

        context.Staff.AddRange(
            new Staff{
                StaffID = "e12345",
                FirstName = "Peter Peter Pumpkin Eater",
                LastName = "the Bald",
                Email ="bingbong@gmail.com" , 
                MobilePhone = "0412345678"
            },
            new Staff{
                StaffID = "e54321",
                FirstName = "Fred",
                LastName = "Fredman" ,
                Email = "fred@gmail.com", 
                MobilePhone = null
            }
        );

        context.SaveChanges();
    }
}