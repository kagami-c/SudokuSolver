using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public class Number
    {
        private int value;
        private bool isReadOnly;

        public Number()
        {
        }

        public Number(int value, bool isReadOnly)
        {
            this.value = value;
            this.isReadOnly = isReadOnly;
        }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                isReadOnly = value;
            }
        }
    }
}
