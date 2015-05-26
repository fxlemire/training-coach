using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCoach {
	class TrainingProgram {

		/**************
		 * ATTRIBUTES *
		 **************/

		private List<TrainingBlock> _blocks = new List<TrainingBlock>();

		/*************
		 * INTERFACE *
		 *************/

		public void create() {
			bool isProgramFinished = false;

			while (!isProgramFinished) {
				TrainingBlock block = new TrainingBlock();
				block.create();
				_blocks.Add(block);

				isProgramFinished = !promptUserForNewBlock();
			}
		}

		public void start() {
			Console.WriteLine("Let's start!");
			
			foreach (TrainingBlock block in _blocks) {
				block.start();
			}

			Console.WriteLine("You are done! Congratulations!");
		}

		/***********
		 * METHODS *
		 ***********/

		private bool promptUserForNewBlock() {
			bool isNewBlockRequested = true;

			Console.WriteLine("Do you want to add a new training block (type 'n' if not, anything else otherwise)?");
			string answer = Console.ReadLine();

			if (answer.Equals("n")) {
				isNewBlockRequested = false;
			}

			return isNewBlockRequested;
		}
	}
}
