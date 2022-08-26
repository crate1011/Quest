using System;

namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }

        public string ShininessDescription
        {
            get
            {
                string theHat = "";
                if (ShininessLevel <= 2)
                {
                    theHat = "dull";
                }
                else if (ShininessLevel >= 2 && ShininessLevel <= 5)
                {
                    theHat = "noticeable";
                }
                else if (ShininessLevel >= 6 && ShininessLevel <= 9)
                {
                    theHat = "bright";
                }
                else if (ShininessLevel > 9)
                {
                    theHat = "blinding";
                }

                return $"{theHat}";
            }
        }
    }
}