using Code.AttachedToObject;
using Code.CodeToSingltoneAndServiceLocator;
using Code.Enemy;
using Code.Interface;
using Code.Object_Pool;
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
        [SerializeField] private float _forceEnemy = 1f;
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private int asteroidNumber = 5;
        [SerializeField] private int enemySpaceShipNumber = 3;
        [SerializeField] private int missilesForPoolNumber = 8;
        [SerializeField] private Sprite _sprite;
        private Camera _camera;
        private ShipMove _shipMove;
        private Fire _fire;
        private Ship _ship;
        private DisplayHp _displayHp;
        private InputController _inputController;
        private ShipInputController _shipInputController;
        private Rigidbody2D _rigidbody;
        private EnemyType _enemyType;
        private EnemyMove _enemyMove;
        private AsteroidController _asteroidController;
        private ServiceLocatorMonoBehaviour _serviceLocatorMono;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            _shipMove = new ShipMove(moveTransform);
            _fire = new Fire(_bullet, _barrel, _sprite);
            _ship = new Ship(_hp);
            _displayHp = new DisplayHp();
            _inputController = new InputController(_shipMove, _fire, _force);
            var getRig = gameObject.TryGetComponent<Rigidbody2D>(out _rigidbody);
            if (!getRig)
            {
                gameObject.AddComponent<Rigidbody2D>();
                _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            }

            _serviceLocatorMono = new ServiceLocatorMonoBehaviour();
            
            _shipInputController = new ShipInputController(_shipMove, gameObject, _camera, _rigidbody);

            AsteroidPool enemyAsteroidPool = new AsteroidPool(asteroidNumber, EnemyType.Asteroid);
            EnemySpaceShipPool enemySpaceShipPool = new EnemySpaceShipPool(enemySpaceShipNumber, EnemyType.EnemySpaceShip);
            
            var enemyAseroid = enemyAsteroidPool.GetEnemy();
            GameObject objectsFromPool = ServiceLocatorMonoBehaviour.GetService<PoolAsteroid>().gameObject;
            var objType = objectsFromPool.GetComponentsInChildren<Transform>();
            GameObject[] obj = new GameObject[objType.Length];
            for (int i = 0; i < objType.Length; i++)
            {
                obj[i] = objType[i].gameObject;
            }
                //enemyAsteroidPool.GetRootPool().gameObject.GetComponentsInChildren<GameObject>();
            PoolsDictionary.AddToDic("Asteroid", enemyAsteroidPool.GetRootPool(), enemyAsteroidPool.GetObjects());
            
            var enemySpaceShip = enemySpaceShipPool.GetEnemy();
            objectsFromPool =  ServiceLocatorMonoBehaviour.GetService<PoolEnemyShip>().gameObject;
                //enemySpaceShipPool.GetRootPool().GetComponentsInChildren<GameObject>();
            
            PoolsDictionary.AddToDic("EnemySpaceShip", enemySpaceShipPool.GetRootPool(), enemySpaceShipPool.GetObjects());

            PlayerMissilesPool playerMissilesPool = new PlayerMissilesPool(missilesForPoolNumber);
            EnemyShipMissilesPool enemyShipMissilesPool = new EnemyShipMissilesPool(missilesForPoolNumber);
            

            var playerMissile = playerMissilesPool.GetBullet();
            objectsFromPool = ServiceLocatorMonoBehaviour.GetService<PoolPlayerMissile>().gameObject; 
                //playerMissilesPool.GetRootPool().GetComponentsInChildren<GameObject>();
            PoolsDictionary.AddToDic("PlayerMissile", playerMissilesPool.GetRootPool(), playerMissilesPool.GetObjects());

            var enemyShipMissile = enemyShipMissilesPool.GetBullet();
            objectsFromPool =  ServiceLocatorMonoBehaviour.GetService<PoolEnemyMissile>().gameObject;
                //enemyShipMissilesPool.GetRootPool().GetComponentsInChildren<GameObject>();
            PoolsDictionary.AddToDic("EnemyShipMissile", enemyShipMissilesPool.GetRootPool(), enemyShipMissilesPool.GetObjects());

            _enemyMove = new EnemyMove(_camera, gameObject.transform);
            _asteroidController = new AsteroidController(_enemyMove, _forceEnemy);

            while (AsteroidController.AsteroidsNumber() <= 3)
            {
                AsterStart();
            }
        }

        private void Update()
        {
            _shipInputController.Execute();
            _inputController.Execute();
        }

        private void FixedUpdate()
        {
            _hpText.text = _displayHp.Display(_hp, _ship.GetHp());
            if (AsteroidController.AsteroidsNumber() <= 3)
            {
                AsterStart();
            }
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

        private void AsterStart()
        {
            var aster = PoolsDictionary.GetFromDic("Asteroid").GetFromPool();
            var asteroid = aster.DeepCopy();
            asteroid.transform.position = _asteroidController.GetPosition(aster).position;
            _asteroidController.AsteroidStart(asteroid);
            StartCoroutine(_asteroidController.LifeTime(asteroid));
        }
    }
}
