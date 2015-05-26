using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* TODO:
 * use TrainingTimer instead of just using wait implementations
 * have a Util class (for methods like wait())
 * refactor start() methods
 * fix the break periods for repetitions/series exercises (implement an infinite wait until user trigger)
 * write tests
 * improve speech for exercises like "jab cross left body punch right body punch left hook uppercut"
 * add more feedback
   * countdown when nearing the end of the exercise / breaks
   * displayed countdown during the exercise
 * improve countdown (seems longer than 1 second between each count (e.g. 3..2..1..)

 * LONG TERM TASKS:
 * implement persistency for programs
 * implement possibilities of modifying programs
 * implement possibilities of deleting programs
 * implement possibility of tracking performance in each exercise
 */

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
