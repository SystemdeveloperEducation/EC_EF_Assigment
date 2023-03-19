// See https://aka.ms/new-console-template for more information
using EF_CodeFirstApp.Models.Forms;
using EF_CodeFirstApp.Services;

var menu = new Menu();
while (true)
{
    await menu.MainMenu();
}
