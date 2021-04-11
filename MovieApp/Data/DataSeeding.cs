using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Entity;
using MovieProject.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Web.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();
            context.Database.Migrate();
            var genres = new List<Genre>()
                          {
                        new Genre {GenreId=1,Name="Komedi",Movies=new List<Movie>(){
                             new Movie {
                                 Title = "3 Aptal Komedi Filmi",
                                 Description = "Farhan Qureshi and Raju Rastogi want to re-unite with their fellow collegian, Rancho, after faking a stroke aboard an Air India plane, and excusing himself from his wife - trouser less - respectively. Enroute, they encounter another student, Chatur Ramalingam, now a successful businessman, who reminds them of a bet they had undertaken 10 years ago. The trio, while recollecting hilarious antics, including their run-ins with the Dean of Delhi's Imperial College of Engineering, Viru Sahastrabudhe, race to locate Rancho, at his last known address - little knowing the secret that was kept from them all this time.",
                                 ImageUrl = "3i.jpg"
                             },

                new Movie {
                    Title = "John Wick Aksiyon Filmi",
                    Description = "Bound by an inescapable blood debt to the Italian crime lord, Santino D'Antonio, and with his precious 1969 Mustang still stolen, John Wick--the taciturn and pitiless assassin who thirsts for seclusion--is forced to visit Italy to honour his promise. But, soon, the Bogeyman will find himself dragged into an impossible task in the heart of Rome's secret criminal society, as every killer in the business dreams of cornering the legendary Wick who now has an enormous price on his head. Drenched in blood and mercilessly hunted down, John Wick can surely forget a peaceful retirement as no one can make it out in one piece.",
                    ImageUrl = "j.jpg"
                },
                        } },
                        new Genre {GenreId=2,Name="Aksiyon"},
                        new Genre {GenreId=3,Name="Romantik"},
                        new Genre {GenreId=4,Name="Dram"},
                        new Genre {GenreId=5,Name="Bilim Kurgu"}                      
                          };
            var movies = new List<Movie>()
            {
                 new Movie {
                     Title = "3 Idiots",
                     Description = "Farhan Qureshi and Raju Rastogi want to re-unite with their fellow collegian, Rancho, after faking a stroke aboard an Air India plane, and excusing himself from his wife - trouser less - respectively. Enroute, they encounter another student, Chatur Ramalingam, now a successful businessman, who reminds them of a bet they had undertaken 10 years ago. The trio, while recollecting hilarious antics, including their run-ins with the Dean of Delhi's Imperial College of Engineering, Viru Sahastrabudhe, race to locate Rancho, at his last known address - little knowing the secret that was kept from them all this time.",
                     ImageUrl = "3i.jpg",
                     Genre=genres[0]
                 },

                new Movie {
                    Title = "John Wick 2",
                    Description = "Bound by an inescapable blood debt to the Italian crime lord, Santino D'Antonio, and with his precious 1969 Mustang still stolen, John Wick--the taciturn and pitiless assassin who thirsts for seclusion--is forced to visit Italy to honour his promise. But, soon, the Bogeyman will find himself dragged into an impossible task in the heart of Rome's secret criminal society, as every killer in the business dreams of cornering the legendary Wick who now has an enormous price on his head. Drenched in blood and mercilessly hunted down, John Wick can surely forget a peaceful retirement as no one can make it out in one piece.",
                    ImageUrl = "j.jpg",
                    Genre=genres[1]
                },
                new Movie {
                    Title = "Aynı Yıldızın Altında",
                    Description = "Hazel and Augustus are two teenagers who share an acerbic wit, a disdain for the conventional, and a love that sweeps them on a journey. Their relationship is all the more miraculous, given that Hazel's other constant companion is an oxygen tank, Gus jokes about his prosthetic leg, and they meet and fall in love at a cancer support group.",
                    ImageUrl = "y.jpg",
                    Genre=genres[2]
                },
                new Movie {
                    Title = "Esaretin Bedeli",
                    Description = "Chronicles the experiences of a formerly successful banker as a prisoner in the gloomy jailhouse of Shawshank after being found guilty of a crime he did not commit. The film portrays the man's unique way of dealing with his new, torturous life; along the way he befriends a number of fellow prisoners, most notably a wise long-term inmate named Red.",
                    ImageUrl = "e.jpg",
                     Genre=genres[3]
                },
                new Movie {
                    Title = "Inception",
                    Description = "Dom Cobb is a skilled thief, the absolute best in the dangerous art of extraction, stealing valuable secrets from deep within the subconscious during the dream state, when the mind is at its most vulnerable. Cobb's rare ability has made him a coveted player in this treacherous new world of corporate espionage, but it has also made him an international fugitive and cost him everything he has ever loved. Now Cobb is being offered a chance at redemption. One last job could give him his life back but only if he can accomplish the impossible, inception. Instead of the perfect heist, Cobb and his team of specialists have to pull off the reverse: their task is not to steal an idea, but to plant one. If they succeed, it could be the perfect crime. But no amount of careful planning or expertise can prepare the team for the dangerous enemy that seems to predict their every move. An enemy that only Cobb could have seen coming.",
                    ImageUrl = "i.jpg",
                     Genre=genres[4]
                }
            };
            var users = new List<User>() {
                new User() {UserName="usera",Email="usera@gmail.com",Password="1234",ImageUrl="person1.jpg"},
                 new User() {UserName="userb",Email="userb@gmail.com",Password="1234",ImageUrl="person2.jpg"},
                  new User() {UserName="userc",Email="userc@gmail.com",Password="1234",ImageUrl="person3.jpg"},
                    new User() {UserName="userd",Email="userd@gmail.com",Password="1234",ImageUrl="person4.jpg"}
            };
            var people = new List<Person>()
            {
                new Person()
                {
                    Name = "Personel2",
                    Biography = "Tanıtım2",
                    User=users[0]
                },
                new Person()
                {
                    Name = "Personel1",
                    Biography = "Tanıtım1",
                     User=users[1]
                }
            };
            var crews = new List<Crew>() { 
                new Crew(){Movie=movies[0],Person=people[0],Job="Yönetmen"},
                 new Crew(){Movie=movies[0],Person=people[1],Job="Yönetmen Yrd."}
            };
            var casts = new List<Cast>() { 
                new Cast(){Movie=movies[0],Person=people[0],Name="Oyuncu Adı 1",Character="Karakter1"},
                new Cast(){Movie=movies[0],Person=people[1],Name="Oyuncu Adı 2",Character="Karakter2"}
            };
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);        
                }
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }
                if (context.Users.Count()==0)
                {
                    context.Users.AddRange(users);
                }
                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }
                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }
                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }
                //if (context.Directors.Count()==0)
                //{
                //    context.Directors.AddRange(directors);
                //}

                context.SaveChanges();
            } }
        }
    }

