using System;
using System.Collections.Generic;

namespace FootballWebSiteApi.Helpers
{
    public class Mapping
    {

        private static Dictionary<string, string> TeamMapping = new Dictionary<string, string> {
            { "MULHOUSE BOURTZ C.S", "Mulhouse Bourtz C.S." },
            { "BANTZENHEIM F.C.", "Bantzenheim F.C."},
            { "HUNINGUE A.S", "Huningue A.S."},
            { "UFFHEIM F.C.", "Uffheim F.C."},
            { "RIEDISHEIM F.C", "Riedisheim F.C."},
            { "ALTKIRCH A.S.", "Altkirch A.S."},
            { "HIRSINGUE U.S", "Hirsingue U.S."},
            { "BALLERSDORF EPA", "Ballersdorf EPA"},
            { "MULHOUSE REAL C.F.", "Mulhouse Real C.F."},
            { "KINGERSHEIM F.C", "Kingersheim F.C."},
            { "PFASTATT F.C.", "Pfastatt F.C."},
            { "BARTENHEIM F.C.", "Bartenheim F.C."},
            { "WITTENHEIM U.S. 2", "Wittenheim U.S. 2"},
            { "MULHOUSE A.S.R.S", "Mulhouse A.S.R.S." },
            { "HABSHEIM F.C.", "Habsheim F.C." },
            { "HIRTZBACH F.C", "Hirtzbach F.C." },
            { "BERRWILLER A.S. 2", "Berrwiller A.S. 2" },
            { "ZILLISHEIM S.S.", "Zillisheim S.S." },
            { "MONTREUX SPORTS", "Montreux Sports" },
            { "MULHOUSE R.C.", "Mulhouse R.C." },

              { "BIESHEIM A.S.C 2", "Biesheim A.S.C. 2" },
              { "A.G.I.I.R. FLORIVAL", "Florival A.G.I.I.R" },
              { "KOETZINGUE A.S.L", "Koetzingue A.S.L." },
              { "BERRWILLER A.S.", "Berrwiller A.S." },
              { "BURNHAUPT LE HT F.C", "Burnhaupt Le Ht F.C." },
              { "SUNDHOFFEN A.S", "Sundhoffen A.S." },
              { "VAGNEY AS", "Vagney A.S." },
              { "MULHOUSE F.C. 2", "Mulhouse F.C. 2" },
              { "SIERENTZ F.C.", "Sierentz F.C." },
              { "ST LOUIS NEUWEG F.C. 2", "Saint-Louis Neuweg F.C. 2" },
              { "KEMBS RÃ‰UNIS F.C", "Kembs F.C." },
              { "ILLZACH A.S.I.M 2", "Illzach A.S.I.M. 2" },

                { "KOETZINGUE A.S.L 2", "Koetzingue A.S.L. 2" },
                  { "BRUNSTATT F.C.", "Brunstatt F.C." },
                    { "BLOTZHEIM A.S.", "Blotzheim A.S." },
                      { "MULHOUSE MOULOUDIA", "Mulhouse Mouloudia" },


        };

        public static string GetTeam(string lafaTeamName)
        {
            string retVal;
            if (TeamMapping.TryGetValue(lafaTeamName.Trim(), out retVal))
            {
                return retVal;
            }
            else
            {
                return lafaTeamName;
            }

            throw new Exception(lafaTeamName + "mapping not found");
        }

    }
}
