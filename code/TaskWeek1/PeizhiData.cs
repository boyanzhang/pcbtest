using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskWeek1
{
    class PeizhiData
    {
        private bool[] _shortChannal;
        private int _shortSelectedNum = 0;


        public PeizhiData()
        {
            _shortChannal = new bool[8];
            for(int i = 0; i < _shortChannal.Length; i++) 
            {
                _shortChannal[i] = false;
            }
        }

        public void shortChannalIsSelected(int channel, bool isSelected)
        {
            if (channel <= 8)
            {
                _shortChannal[channel - 1] = isSelected;
                if (isSelected)
                {
                    _shortSelectedNum++;
                }
                else
                {
                    _shortSelectedNum--;
                }
            }
            
        }
    }
}
