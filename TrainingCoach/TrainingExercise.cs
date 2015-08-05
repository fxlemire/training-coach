using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCoach {
	class TrainingExercise {

		enum Type {
			NONE,
			DURATION,
			SERIES_REPETITIONS
		}

		/**************
		 * ATTRIBUTES *
		 **************/

		private int _breakDuration = 0;
		private int _duration;
		private int _repetitions;
		private int _series;
		private String _name;
		private Type _type;

		/*************
		 * INTERFACE *
		 *************/

		public void create() {
			promptExerciseName();
			promptExerciseType();

			if (_type == Type.DURATION) {
				promptExerciseDuration();
			} else if (_type == Type.SERIES_REPETITIONS) {
				promptExerciseRepetitions();
				promptExerciseSeries();

				if (_series > 1) {
					promptExerciseBreakDuration();
				}
			}
		}

		public void start() {
			string sentence = processSentence();
			SpeechSynthesizer synthesizer = new SpeechSynthesizer();
			synthesizer.Speak(sentence);

			wait(2000);

			synthesizer.Speak("Let's start!");

			countdown(3);

			int loop = 1;

			if (_type == Type.SERIES_REPETITIONS) {
				loop = _series;
			}

			while (loop > 0) {
				synthesizer.SpeakAsync("GO!");
				wait(_duration * 1000);
				synthesizer.Speak("Break time!");
				wait(_breakDuration * 1000);
				--loop;
			}
		}

		/***********
		 * METHODS *
		 ***********/

		private void countdown(int duration) {
			SpeechSynthesizer synthesizer = new SpeechSynthesizer();

			while (duration > 0) {
				synthesizer.SpeakAsync(Convert.ToString(duration));
				wait(1000);
				--duration;
			}
		}

		private string processSentence() {
			string sentence = _name;

			switch (_type) {
				case Type.DURATION:
					sentence += " for ";
					sentence += _duration + " seconds.";
					break;
				case Type.SERIES_REPETITIONS:
					sentence += ". Do " + _series + " series of " + _repetitions + " repetitions.";
					sentence += "Take " + _breakDuration + " seconds of break between each serie.";
					break;
				case Type.NONE:
				default:
					break;
			}

			return sentence;
		}

		private void promptExerciseName() {
			Console.WriteLine("Enter the name of your exercise:");
			_name = Console.ReadLine();
		}

		private void promptExerciseType() {
			Console.WriteLine("Based on duration (1) or series & repetitions(2)?");
			int exerciseType = Convert.ToInt32(Console.ReadLine());

			switch (exerciseType) {
				case 1:
					_type = Type.DURATION;
					break;
				case 2:
					_type = Type.SERIES_REPETITIONS;
					break;
				default:
					_type = Type.NONE;
					break;
			}
		}

		private void promptExerciseDuration() {
			Console.WriteLine("For how long (in seconds)?");
			_duration = Convert.ToInt32(Console.ReadLine());
		}

		private void promptExerciseRepetitions() {
			Console.WriteLine("How many repetitions?");
			_repetitions = Convert.ToInt32(Console.ReadLine());
		}

		private void promptExerciseSeries() {
			Console.WriteLine("How many series?");
			_series = Convert.ToInt32(Console.ReadLine());
		}

		private void promptExerciseBreakDuration() {
			Console.WriteLine("How long of a break between each series (in seconds)?");
			_breakDuration = Convert.ToInt32(Console.ReadLine());
		}

		private void wait(int duration) {
			System.Threading.Thread.Sleep(duration);
		}
	}
}