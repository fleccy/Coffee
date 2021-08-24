using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elsa.Activities.Signaling.Services;
using Elsa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coffee.Pages
{

    public class TriggerWorkflowModel : PageModel
    {
        ISignaler _signaler;

        public TriggerWorkflowModel(ISignaler signaler)
        {
            _signaler = signaler;
        }

        CoffeeType coffeeTypes;

        public void OnGet()
        {
            coffeeTypes = new CoffeeType { Id = 1, Coffee = "Latte", Name = "Andrew", Sugar = false };
            Variables input = new();
            input.Set("Coffee", coffeeTypes);
            _signaler.TriggerSignalAsync("Coffee", input);
        }
    }
}