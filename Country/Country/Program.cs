using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestApp.ColoredConsole;
using System.Drawing;

namespace TestApp
{
    internal class District
    {
        internal string name;
        internal int number;
    }
    internal class City
    {
        private static int population;
        internal City(string n)
        {
            name = n;
        }

        internal bool AddLanguage(string lang)
        {
            if (!_languages.Contains(lang))
            {
                _languages.Add(lang);
                return true;
            }
            else
                return false;
        }

        internal string name;

        private List<string> _languages = new List<string>();

        internal List<string> languages { get { return _languages; } }

        private District[] _districts;

        internal District[] districts
        {
            get
            {
                return _districts;
            }
            set
            {
                _districts = value;
            }
        }
    }

    internal class National
    {
        internal National(string n, Color nfc)
        {
            name = n;
            _nationalFlagColors = nfc;
        }
        private string _name;
        private Color _nationalFlagColors;

        internal string name { get { return _name; } set { _name = value; } }
    }

    internal static class Country
    {
        internal static City[] cities;
        internal static National[] nationals;

        private static string _name;
        private static int _population;

        internal static string name { get { return _name; } set { _name = value; } }
        internal static int population { get { return _population; } set { _population = value; } }
    }
}
