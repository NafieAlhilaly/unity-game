using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Hunter;

public class HunterTestStates
{
    [Test]
    public void TestEnteringIdleState()
    {
        // Arrange
        HunterTest_MockStateManager HunterTest_MockStateManager = new HunterTest_MockStateManager();
        IdleState IdleState = new IdleState();

        // Act
        HunterTest_MockStateManager.Start();

        // Assert
        Assert.AreEqual(HunterTest_MockStateManager.CurrentState.GetType(), IdleState.GetType());
    }

    [Test]
    public void TestEnteringCleaveState()
    {
        // Arrange
        HunterTest_MockStateManager HunterTest_MockStateManager = new HunterTest_MockStateManager();
        CleaveState CleaveState = new CleaveState();

        // Act
        HunterTest_MockStateManager.Start();
        HunterTest_MockStateManager.Update();

        // Assert
        Assert.AreEqual(HunterTest_MockStateManager.CurrentState.GetType(), CleaveState.GetType());
    }

    [Test]
    public void TestEnteringIdleStateFromCleaveState()
    {
        // Arrange
        HunterTest_MockStateManager HunterTest_MockStateManager = new HunterTest_MockStateManager();
        IdleState IdleState = new IdleState();

        // Act
        HunterTest_MockStateManager.Start();
        HunterTest_MockStateManager.Update();
        HunterTest_MockStateManager.SwitchState(IdleState);

        // Assert
        Assert.AreEqual(HunterTest_MockStateManager.CurrentState.GetType(), IdleState.GetType());
    }
}

class HunterTest_MockStateManager : StateManager
{

    public BaseState CurrentState;
    public CleaveState CleaveState = new CleaveState();
    public IdleState IdleState = new IdleState();
    public bool IsWaiting = true;

    public void Start()
    {
        CurrentState = IdleState;
        CurrentState.UpdateState(this);
    }

    public void Update()
    {
        CurrentState.UpdateState(this);
        if (CurrentState == IdleState && IsWaiting)
        {
            SwitchState(CleaveState);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        CurrentState.ApplyPlayerEffect();
    }

    public void SwitchState(BaseState state)
    {
        CurrentState = state;
        state.StartState(this);
    }
}