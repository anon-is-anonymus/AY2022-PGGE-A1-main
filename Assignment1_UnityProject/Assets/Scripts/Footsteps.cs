using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
	[SerializeField]
	private AudioClip[] concreteClips;
	[SerializeField]
	private AudioClip[] dirtClips;
	[SerializeField]
	private AudioClip[] metalClips;
	[SerializeField]
	private AudioClip[] sandClips;
	[SerializeField]
	private AudioClip[] woodClips;

	public AudioSource audioSource;
	public CharacterController characterController;

	// Start is called before the first frame update
	void Start()
	{
	}

	void Step()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.down, out hit, 3))
		{
			if (hit.transform.gameObject.layer == 9) //Check if ground is concrete
			{
				AudioClip clip = concreteClips[Random.Range(0, concreteClips.Length)];
				audioSource.volume = Random.Range(0.2f, 1); //Randomise loudness of footsteps
				audioSource.PlayOneShot(clip);
				Debug.Log("Playing");
			}
			if (hit.transform.gameObject.layer == 10) //Check if ground is dirt
			{
				AudioClip clip = dirtClips[Random.Range(0, dirtClips.Length)];
				audioSource.volume = Random.Range(0.2f, 1); //Randomise loudness of footsteps
				audioSource.PlayOneShot(clip);
			}
			if (hit.transform.gameObject.layer == 11) //Check if ground is metal
			{
				AudioClip clip = metalClips[Random.Range(0, metalClips.Length)];
				audioSource.volume = Random.Range(0.2f, 1); //Randomise loudness of footsteps
				audioSource.PlayOneShot(clip);
			}
			if (hit.transform.gameObject.layer == 12) //Check if ground is sand
			{
				AudioClip clip = sandClips[Random.Range(0, sandClips.Length)];
				audioSource.volume = Random.Range(0.2f, 1); //Randomise loudness of footsteps
				audioSource.PlayOneShot(clip);
			}
			if (hit.transform.gameObject.layer == 13) //Check if ground is wood
			{
				AudioClip clip = woodClips[Random.Range(0, woodClips.Length)];
				audioSource.volume = Random.Range(0.2f, 1); //Randomise loudness of footsteps
				audioSource.PlayOneShot(clip);
			}
		}
	}    

	// Update is called once per frame
	void Update()
	{
		
	}
}
