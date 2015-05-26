using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCoach {
	class TrainingBlock {

		/**************
		 * ATTRIBUTES *
		 **************/
		private int _series;
		private int _breakBetweenExercises = 0;

		private List<TrainingExercise> _exercises = new List<TrainingExercise>();

		/*************
		 * INTERFACE *
		 *************/

		public void create() {
			bool isBlockFinished = false;

			while (!isBlockFinished) {
				TrainingExercise exercise = new TrainingExercise();
				exercise.create();
				_exercises.Add(exercise);

				isBlockFinished = !promptUserForNewExercise();
			}

			promptBlockSeries();

			if (_exercises.Count > 1 || _series > 1) {
				promptBlockBreakBetweenExercises();
			}
		}

		public void start() {
			SpeechSynthesizer synthesizer = new SpeechSynthesizer();
			synthesizer.Speak("New block.");

			foreach (TrainingExercise exercise in _exercises) {
				exercise.start();
				synthesizer.Speak("Break for " + _breakBetweenExercises + " seconds.");
				wait(_breakBetweenExercises);
			}
		}

		/***********
		 * METHODS *
		 ***********/

		private void promptBlockSeries() {
			Console.WriteLine("How many series of this block?");
			_series = Convert.ToInt32(Console.ReadLine());
		}

		private void promptBlockBreakBetweenExercises() {
			Console.WriteLine("How long of a break between each exercise?");
			_breakBetweenExercises = Convert.ToInt32(Console.ReadLine());
		}

		private bool promptUserForNewExercise() {
			bool isNewExerciseRequested = true;

			Console.WriteLine("Do you want to add a new training exercise (type 'n' if not, anything else otherwise)?");
			string answer = Console.ReadLine();

			if (answer.Equals("n")) {
				isNewExerciseRequested = false;
			}

			return isNewExerciseRequested;
		}

		private void wait(int duration) {
			System.Threading.Thread.Sleep(duration);
		}
	}
}