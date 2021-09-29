using Code.UI;
using TMPro;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private TextMeshProUGUI _hpText;
        private Camera _camera;
        private ShipMove _shipMove;
        private Fire _fire;
        private Ship _ship;
        private DisplayHp _displayHp;
        private InputController _inputController;
        private ShipInputController _shipInputController;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            _shipMove = new ShipMove(moveTransform);
            _fire = new Fire(_bullet, _barrel);
            _ship = new Ship(_hp);
            _displayHp = new DisplayHp();
            _inputController = new InputController(_shipMove, _fire, _force);
            var getRig = gameObject.TryGetComponent<Rigidbody2D>(out _rigidbody);
            if (!getRig)
            {
                gameObject.AddComponent<Rigidbody2D>();
                _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            }

            _shipInputController = new ShipInputController(_shipMove, gameObject, _camera, _rigidbody);
        }

        private void Update()
        {
            _shipInputController.Execute();
            _inputController.Execute();
        }

        private void FixedUpdate()
        {
            _hpText.text = _displayHp.Display(_hp, _ship.GetHp());
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_ship.GetHp() < 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _ship.ChangeHp();
            }
        }
    }
}
