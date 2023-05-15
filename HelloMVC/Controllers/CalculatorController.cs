using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloMVC.Models;

namespace HelloMVC.Controllers
{
    public class CalculatorController : Controller
    {
        static string log = "";

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Calculus());
        }

        [HttpPost]
        public IActionResult Index([FromForm] Calculus calculation)
        {
            try
            {
                switch (calculation.Operand)
                {
                    case "+":
                        calculation.Result = calculation.Nr1 + calculation.Nr2;
                        break;
                    case "-":
                        calculation.Result = calculation.Nr1 - calculation.Nr2;
                        break;
                    case "*":
                        calculation.Result = calculation.Nr1 * calculation.Nr2;
                        break;
                    case "/":
                        try
                        {                                                
                                calculation.Result = calculation.Nr1 / calculation.Nr2;                                               
                        }
                        catch (DivideByZeroException ex )
                        {

                            calculation.ErrorMessage = ex.Message;
                        }
                    //    calculation.Result = calculation.Nr1 / calculation.Nr2;
                       break;
                    default:
                       break;
                }
            }
            catch (Exception)
            {
                calculation.ErrorMessage = "An error occurred during calculation.";
            }
            log += $"  {calculation.Nr1} {calculation.Operand} {calculation.Nr2} = {calculation.Result} <br>";

            ViewBag.Log = log;
            return View(calculation);

        }

        }
}
