using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayButtonStartsPlay() 
    {
        // Load the scene
        SceneManager.LoadScene("Intro");
        yield return null; // Wait for one frame to ensure the scene is loaded

        // Find the play button
        GameObject playButtonObj = GameObject.Find("PlayButton");
        Assert.IsNotNull(playButtonObj, "Play button not found in the scene.");

        // Get the Button component from the play button object
        Button playButton = playButtonObj.GetComponent<Button>();
        Assert.IsNotNull(playButton, "Button component not found on the play button.");

        // Simulate clicking the play button
        playButton.onClick.Invoke();
        yield return null; // Wait for one frame for the scene to load

        // Assert that the correct scene is loaded
        Scene currentScene = SceneManager.GetActiveScene();
        Assert.AreEqual("Game", currentScene.name, "Expected 'Game' but got " + currentScene.name);
    }

    [UnityTest]
    public IEnumerator StopButtonStopsPlay()
    {
        // Load the scene
        SceneManager.LoadScene("Game");
        yield return null; // Wait for one frame to ensure the scene is loaded

        // Find the play button
        GameObject stopButtonObj = GameObject.Find("StopButton");
        Assert.IsNotNull(stopButtonObj, "Stop button not found in the scene.");

        // Get the Button component from the play button object
        Button stopButton = stopButtonObj.GetComponent<Button>();
        Assert.IsNotNull(stopButton, "Button component not found on the stop button.");

        // Simulate clicking the play button
        stopButton.onClick.Invoke();
        yield return null; // Wait for one frame for the scene to load

        // Assert that the correct scene is loaded
        Scene currentScene = SceneManager.GetActiveScene();
        Assert.AreEqual("Exit", currentScene.name, "Expected 'Exit' but got " + currentScene.name);
    }

    [UnityTest]
    public IEnumerator PlayAgainButtonRestartsGame()
    {
        // Load the scene
        SceneManager.LoadScene("Exit");
        yield return null; // Wait for one frame to ensure the scene is loaded

        // Find the play button
        GameObject playAgainButtonObj = GameObject.Find("PlayAgainButton");
        Assert.IsNotNull(playAgainButtonObj, "Play again button not found in the scene.");

        // Get the Button component from the play button object
        Button playAgainButton = playAgainButtonObj.GetComponent<Button>();
        Assert.IsNotNull(playAgainButton, "Button component not found on the play again button.");

        // Simulate clicking the play button
        playAgainButton.onClick.Invoke();
        yield return null; // Wait for one frame for the scene to load

        // Assert that the correct scene is loaded
        Scene currentScene = SceneManager.GetActiveScene();
        Assert.AreEqual("Intro", currentScene.name, "Expected 'Intro' but got " + currentScene.name);
    }

    [UnityTest]
    public IEnumerator PlayerNameShowsInGame()
    {
        SceneManager.LoadScene("Game");
        yield return null;

        GameObject nameTextObj = GameObject.Find("NameText");
        Assert.IsNotNull(nameTextObj, "Name text not located");

        Text nameText = nameTextObj.GetComponent<Text>();

        Assert.IsNotNull(nameText.text);
    }

    public IEnumerator DestroyingFiveTargetsStopsPlay()
    {
        SceneManager.LoadScene("Game");
        yield return null;

        GameObject target_1 = GameObject.Find("Target_1");
        GameObject target_2 = GameObject.Find("Target_2");
        GameObject target_3 = GameObject.Find("Target_3");
        GameObject target_4 = GameObject.Find("Target_4");
        GameObject target_5 = GameObject.Find("Target_5");
        ScoreControl scoreControl = new ScoreControl();
        Object.Destroy(target_1);
        scoreControl.score += 1;
        Object.Destroy(target_2);
        scoreControl.score += 1;
        Object.Destroy(target_3);
        scoreControl.score += 1;
        Object.Destroy(target_4);
        scoreControl.score += 1;
        Object.Destroy(target_5);
        scoreControl.score += 1;

        yield return new WaitForSeconds(2);

        Scene currentScene = SceneManager.GetActiveScene();
        Assert.AreEqual("Exit", currentScene.name);
    }
}
