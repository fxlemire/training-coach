using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCoach {
	class TrainingCoach {

		/**************
		 * ATTRIBUTES *
		 **************/

		private List<TrainingProgram> _programs = new List<TrainingProgram>();

		/*************
		 * INTERFACE *
		 *************/

		public void start() {
			TrainingProgram program = new TrainingProgram();
			program.create();
			program.start();
		}
	}
}
