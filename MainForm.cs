using System.Drawing;
using System.Windows.Forms;

namespace afd_porta_automatica
{
    public partial class MainForm : Form
    {
        private readonly AutomaticDoor door = new AutomaticDoor();

        public MainForm()
        {
            InitializeComponent();
            UpdateInterface();
            movementTimer.Interval = 500; // Corrigido de 'movement' para 'movementTimer'
        }

        private void UpdateInterface()
        {
            pbDoorPosition.Value = door.DoorPosition; // Corrigido 'phDoorPosition' para 'pbDoorPosition'
            lblStatus.Text = $@"Estado: {door.CurrentState} ({door.DoorPosition}%)";

            pbDoorPosition.ForeColor = door.CurrentState switch // Removido parênteses extra
            {
                AutomaticDoor.DoorState.Opening => Color.Orange,
                AutomaticDoor.DoorState.Closing => Color.Orange,
                AutomaticDoor.DoorState.Open => Color.LimeGreen,
                _ => Color.Red
            };
        }

        private void movementTimer_Tick(object sender, System.EventArgs e)
        {
            door.UpdatePosition();
            UpdateInterface();

            // Corrigido a condição usando operador lógico correto
            if (door.CurrentState != AutomaticDoor.DoorState.Opening &&
                door.CurrentState != AutomaticDoor.DoorState.Closing)
            {
                movementTimer.Stop();
            }
        }

        private void btnPresence_Click(object sender, System.EventArgs e)
        {
            door.ProcessEvent(DoorEvent.PresenceDetected);
            HandleMovement();
        }

        private void btnAbsence_Click(object sender, System.EventArgs e)
        {
            door.ProcessEvent(DoorEvent.AbsenceDetected);
            HandleMovement();
        }

        private void btnObstacle_Click(object sender, System.EventArgs e)
        {
            door.ProcessEvent(DoorEvent.SafetyObstacle);
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (door.CurrentState == AutomaticDoor.DoorState.Opening ||
                door.CurrentState == AutomaticDoor.DoorState.Closing)
            {
                movementTimer.Start();
            }
            UpdateInterface();
        }
    }
}