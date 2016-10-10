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
            Get("/{id}", async args =>
            {
                string Name = "";
                // object sprites = "";
                long Weight = 0;
                long Height = 0;

                string url = "http://pokeapi.co/api/v2/pokemon/";
                try
                {
                    url += (int)args.id;
                }
                catch
                {
                    url += "151";
                }

                // Our anonymous function is a parameter of type Action that returns a Dictionary
                await WebRequest.SendRequest(url, new Action<Dictionary<string, object>>( JsonResponse =>
                    {
                        Name = (string)JsonResponse["name"];
                        // sprites = (object)JsonResponse["sprites"];
                        Weight = (long)JsonResponse["weight"];
                        Height = (long)JsonResponse["height"];
                        // exp = (long)JsonResponse["base_experience"];
 
                        @ViewBag.name = Name;
                        @ViewBag.weight = Weight;
                        @ViewBag.height = Height;
                        // @ViewBag.exp = exp; 
                    }
                ));
                return View["poke.sshtml"];
            }); 
        }
    }
}