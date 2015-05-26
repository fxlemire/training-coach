using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCoach {
	class TrainingTimer {

		/**************
		 * ATTRIBUTES *
		 **************/

		private int _duration;

		private System.Windows.Forms.Timer _timer;
		private static TrainingTimer _trainingTimer = null;

		/*************
		 * SINGLETON *
		 *************/

		private TrainingTimer() {
		}

		public static TrainingTimer getInstance() {
			if (_trainingTimer == null) {
				_trainingTimer = new TrainingTimer();
			}

			return _trainingTimer;
		}

		/*************
		 * INTERFACE *
		 *************/

		public void startCountdown(int duration) {
			_duration = duration;

			if (_timer != null) {
				_timer.Stop();
			}

			_timer = new System.Windows.Forms.Timer();
			_timer.Tick += new EventHandler(trainingTimer_Tick);
			_timer.Interval = 1000;
			_timer.Start();
		}

		/***********
		 * METHODS *
		 ***********/

		private void trainingTimer_Tick(object sender, EventArgs e) {
			_duration--;

			if (_duration <= 0) {
				_timer.Stop();
			}

			printTimeLeft();
		}

		private void printTimeLeft() {
			string timeUnit = "second";

			if (_duration > 1) {
				timeUnit += "s";
			}

			Console.WriteLine(_duration + " " + timeUnit + " remaining");
		}
	}
}
