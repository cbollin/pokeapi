using Nancy;
using System;
using System.Collections.Generic;
using ApiCaller;
namespace poke1
{
    public class PokeModule : NancyModule
    {
        public PokeModule()
        {
            Get("/", async args =>
            {
                string Name = "";
                long Weight = 0;
                long Height = 0;
                object Front = "";
                // string Sprite = "";
                // Our anonymous function is a parameter of type Action that returns a Dictionary
                await WebRequest.SendRequest("http://pokeapi.co/api/v2/pokemon/25", new Action<Dictionary<string, object>>( JsonResponse =>
                    {
                        Name = (string)JsonResponse["name"];
                        Weight = (long)JsonResponse["weight"];
                        Height = (long)JsonResponse["height"];
                        Front = (object)JsonResponse["sprites"];
                        // Sprite = (string)JsonResponse["back_female"];
                        Console.WriteLine(Front);
                        // Console.WriteLine(Sprite);
                    }
                ));
                ViewBag.Name = Name;
                ViewBag.Weight = Weight;
                ViewBag.Height = Height;
                ViewBag.Front = Front;
                // ViewBag.Sprite = Sprite;
                return View["poke.sshtml"];
            });
        }
    }
}