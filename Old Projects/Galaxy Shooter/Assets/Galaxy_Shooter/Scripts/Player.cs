using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _playerExplosion;
    [SerializeField]
    private GameObject _playerShield;
    [SerializeField]
    private GameObject[] _engines;

    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;
    // [SerializeField]
    public bool _canTripShot = false;
    public bool canSpeed = false;
    public int lives = 3;
    public bool canShield = false;
    private UIManager _uimanager;
    private AudioSource _audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uimanager != null)
        {
            _uimanager.UpdateLives(lives);
        }
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { 
       Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    private void Movement()
    {
        float sp;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");
        float x = transform.position.x;
        float y = transform.position.y;

        if (canSpeed)
            sp = 3.0f * _speed * Time.deltaTime;
        else
            sp = _speed * Time.deltaTime;

        transform.Translate(Vector3.right * sp * horizontalInput);
        transform.Translate(Vector3.up * sp * verticallInput);

        if (x > 9)
        {
            transform.position = new Vector3(-9f, y, 0);
        }
        else if (x < -9)
        {
            transform.position = new Vector3(9f, y, 0);
        }

        if (y > 5)
        {
            transform.position = new Vector3(x, -5f, 0);
        }
        else if (y < -5)
        {
            transform.position = new Vector3(x, 5f, 0);
        }

    }

    private void Shoot()
    {
        _audioSource.Play();
        if (Time.time > _canFire)
        {
            if (_canTripShot)
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            else
                Instantiate(_laserPrefab, transform.position + new Vector3(0, .8f, 0), Quaternion.identity);
           
             _canFire = Time.time + _fireRate;
        }
    }

    public void TripShotOn()
    {
        _canTripShot = true;
        StartCoroutine(TripShotPowerDown());
    }

    public IEnumerator TripShotPowerDown()
    {
        yield return new WaitForSeconds(5);
        _canTripShot = false;
    }

    public void SpeedBoostOn()
    {
        canSpeed = true;
        StartCoroutine(SpeedBoostOff());
    }

    public IEnumerator SpeedBoostOff()
    {
        yield return new WaitForSeconds(5);
        canSpeed = false;
    }

    public void ShieldOn()
    {
        canShield = true;
        _playerShield.SetActive(true);

    }

    public void ShieldOff()
    {
        canShield = false;
        _playerShield.SetActive(false);

    }

    public void Damage()
    {
        if (canShield)
        {
            ShieldOff();
            return;
        }

        lives--;

        if (lives == 2)
        {
            _engines[0].SetActive(true);
        }
        else if(lives == 1)
        {
            _engines[1].SetActive(true);
        }

        if (_uimanager != null)
        {
            _uimanager.UpdateLives(lives);
        }

        if (lives == 0)
        {
            Instantiate(_playerExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            _uimanager.StartScreenOn();
        }
    }
}