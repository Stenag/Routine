using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routine
{
    public class Task
    {
        /// <summary>
        /// The text associated to the task.
        /// </summary>
        public String Label { get; /*private*/ set; }
        /// <summary>
        /// The time a task has to wait when it's been validated to appear again.
        /// Unit : Day
        /// </summary>
        public int Period { get; /*private*/ set; }
        /// <summary>
        /// The last time the task has been validated
        /// </summary>
        private DateTime LastValidation;

        /// <summary>
        /// Do not use.
        /// </summary>
        public Task() { }

        public Task(String label, int period)
        {
            this.Label = label;
            this.Period = period;
            this.LastValidation = DateTime.UtcNow.AddDays(-(period + 1));
        }
    }
}
