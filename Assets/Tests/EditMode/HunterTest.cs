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
    [Test]
    public void TestIncreaseCleaveCount()
    {
        // Arrange
        HunterTest_MockStateManager HunterTest_MockStateManager = new HunterTest_MockStateManager();
        CleaveState CleaveState = new CleaveState();
        HunterTest_MockStateManager.CleaveState = CleaveState;

        // Act
        HunterTest_MockStateManager.Start();
        HunterTest_MockStateManager.SwitchState(CleaveState);
        HunterTest_MockStateManager.SwitchState(CleaveState);
        HunterTest_MockStateManager.SwitchState(CleaveState);

        // Assert
        Assert.AreEqual(HunterTest_MockStateManager.CleaveState.CleaveCount, 3);
    }
    [Test]
    public void TestEnteringRageStateFromCleaveStateAfter3Cleaves()
    {
        // Arrange
        HunterTest_MockStateManager HunterTest_MockStateManager = new HunterTest_MockStateManager();
        CleaveState CleaveState = new CleaveState();
        HunterTest_MockStateManager.CleaveState = CleaveState;
        RageState RageState = new RageState();

        // Act
        HunterTest_MockStateManager.Start();
        HunterTest_MockStateManager.SwitchState(CleaveState);
        HunterTest_MockStateManager.SwitchState(CleaveState);
        HunterTest_MockStateManager.SwitchState(CleaveState);
        HunterTest_MockStateManager.SwitchState(CleaveState);
        HunterTest_MockStateManager.CleaveState.CleaveDone = true;
        HunterTest_MockStateManager.Update();

        // Assert
        Assert.AreEqual(HunterTest_MockStateManager.CleaveState.CleaveCount, 4);
        Assert.AreEqual(HunterTest_MockStateManager.CurrentState.GetType(), RageState.GetType());
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
        if (CleaveState.CleaveDone && CleaveState.CleaveCount >= 3)
        {
            SwitchState(RageState);
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