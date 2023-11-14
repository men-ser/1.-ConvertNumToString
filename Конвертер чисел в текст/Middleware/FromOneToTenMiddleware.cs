using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ConvertNumToString.Middleware
{
    public class FromOneToTenMiddleware
    {
        private readonly RequestDelegate _next;

        public FromOneToTenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"];
            try
            {
                int number = Convert.ToInt32(token);
                number = Math.Abs(number);
                string[] Numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

                if (number < 1000)
                {
                    string? hnd1 = string.Empty;
                    hnd1 = context.Session.GetString("num1hnd");
                    string? ten1 = string.Empty;
                    ten1 = context.Session.GetString("num1ten");
                    int num1 = Convert.ToInt32(context.Session.GetString("num1"));
                    if (hnd1 == null)
                    {
                        if (ten1 == null)
                        {
                            if (number == 10)
                                await context.Response.WriteAsync("Your number is: ten");
                            else
                                await context.Response.WriteAsync("Your number is: " + Numbers[number - 1]);
                        }
                        else
                        {
                            number %= 10;
                            await context.Response.WriteAsync("Your number is: " + ten1 + " " + (number == 0 ? "" :Numbers[number - 1]));
                        }
                    }
                    else
                    {
                        if (ten1 == null)
                        {
                            if (num1 == 10)
                                await context.Response.WriteAsync("Your number is: " + hnd1 + "ten");
                            else
                                await context.Response.WriteAsync("Your number is: " + hnd1 + " " + Numbers[num1 - 1]);
                        }
                        else
                        {
                            num1 %= 10;
                            await context.Response.WriteAsync("Your number is: " + hnd1 +" "+ ten1 + " " + (num1 == 0 ? "" : Numbers[num1 - 1]));
                        }

                    }

                }

                else
                {
                    string? hnd1 = string.Empty;
                    string? hnd2 = string.Empty;
                    hnd1 = context.Session.GetString("num1hnd");
                    hnd2 = context.Session.GetString("num2hnd");
                    string? ten1 = string.Empty;
                    string? ten2 = string.Empty;
                    ten1 = context.Session.GetString("num1ten");
                    ten2 = context.Session.GetString("num2ten");
                    string? elv1 = string.Empty;
                    string? elv2 = string.Empty;
                    elv1 = context.Session.GetString("num1elv");
                    elv2 = context.Session.GetString("num2elv");
                    int num1 = Convert.ToInt32(context.Session.GetString("num1"));
                    int num2 = Convert.ToInt32(context.Session.GetString("num2"));
                    string? numSubResult1 = string.Empty;
                    string? numSubResult2 = string.Empty;

                    if (elv1 == null) { num1 %= 10; numSubResult1 = (ten1 == null ? "" : ten1+" ") + (num1 == 0 ? "" : Numbers[num1 - 1]); }
                    else numSubResult1 = elv1;
                    if (elv2 == null) { num2 %= 10; numSubResult2 = (ten2 == null ? "" : ten2 + " ") + (num2 == 0 ? "" : Numbers[num2 - 1]); }
                    else numSubResult2 = elv2;

                    if (ten2 == null && elv2 == null)
                        {
                            num2 %= 10;
                            if (hnd1 == null)
                            {
                                if (ten1 == null && elv1 == null)
                                {
                                    if (num1 == 10 )
                                        await context.Response.WriteAsync("Your number is: " + Numbers[num2 - 1] + " thousand " + "ten");
                                    else
                                    {
                                        num1 %= 10;
                                        await context.Response.WriteAsync("Your number is: " + Numbers[num2 - 1] + " thousand " + (num1 == 0 ? "" : Numbers[num1 - 1]));
                                    }
                                }
                                else
                                {
                                        await context.Response.WriteAsync("Your number is: " + Numbers[num2 - 1] + " thousand " + numSubResult1);
                                }
                            }
                            else
                            {
                                if (ten1 == null && elv1 == null)
                                {
                                    if (num1 == 10)
                                        await context.Response.WriteAsync("Your number is: " + Numbers[num2 - 1] + " thousand " + hnd1 + "ten");
                                    else
                                        await context.Response.WriteAsync("Your number is: " + Numbers[num2 - 1] + " thousand " + hnd1 + " " + (num1 == 0 ? "" : Numbers[num1 - 1]));
                                }
                                else
                                {
                                    await context.Response.WriteAsync("Your number is: " + Numbers[num2 - 1] + " thousand " + hnd1 + " " + numSubResult1);
                                }

                            }
                        }
                    else
                        {
                            num2 %= 10;
                            if (hnd1 == null)
                            {
                                if (ten1 == null && elv1 == null)
                                {
                                    if (num1 == 10)
                                        await context.Response.WriteAsync("Your number is: " + numSubResult2 + " thousand " + " " + "ten");
                                    else
                                        await context.Response.WriteAsync("Your number is: " + numSubResult2 + " thousand " + (num1 == 0 ? "" : Numbers[num1 - 1]));
                                }
                                else
                                    //num1 %= 10;
                                    await context.Response.WriteAsync("Your number is: " + numSubResult2 + " thousand " + numSubResult1);
                               
                            }
                            else
                            {
                                if (ten1 == null && elv1==null)
                                {
                                    if (num1 == 10)
                                        await context.Response.WriteAsync("Your number is: " + numSubResult2 + " thousand " + hnd1 + " " + "ten");
                                    else
                                        await context.Response.WriteAsync("Your number is: " + numSubResult2 + " thousand " + hnd1 + " " + (num1 == 0 ? "" : Numbers[num1 - 1]));
                                }
                                else
                                {
                                   
                                    await context.Response.WriteAsync("Your number is: " + numSubResult2 + " thousand " + hnd1 + " " + numSubResult1);
                                }

                            }

                        }
                    }
                context.Session.Clear();
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter");
            }
        }
    }
}