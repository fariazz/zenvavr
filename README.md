# zenvavr
Lightweight, minimal VR library for Unity 2019.3 onwards

**Zenva VR**, is a VR library made at Zenva. It features drag-and-drop components and prefabs to create a wide range of VR experiences. Here are many of the systems the libary includes:
- Complete VR rigs (both room-scale and stationary)
- Grabbing (picking up and throwing objects)
- Teleportation
- Laser pointer
- Interactable objects
- Button and axis detection

# Prefabs
Here's a look at the included prefabs located in the **ZenvaVR/Toolkit/Prefabs** folder.
- **XR Rig Tracked Controllers**: Room-scale VR rig with laser pointer hands.
- **XR Rig Tracked Controllers - Grab**: Room-scale VR rig with grab hands.
- **XR Rig Cardboard**: VR rig for the Google cardboard and other stationary, reticle based headsets.
- **Robo Hand**: VR controller prefab.
- **Laser Pointer**: Allows you to interact with objects from a distance (attach as a child of the Left/Right Hand object).
- **Free Teleportation Controller**: Enables free teleportation for your rig (attach as a child of the FloorOffset).

# Scripts
Here's a look at the included scripts located in the **ZenvaVR/Toolkit/Scripts** folder.
- **AutoPoseSource.cs**: Used for VR with one controller. Switches over controller source (left or right handed) based on the device's settings. Attach to the controller object.
- **AxisController.cs**: Can detect an axis input and call respective events.
- **ButtonController.cs**: Can detect a button input and call respective events.
- **CardboardInputCheck.cs**: Calls an event when the Google Cardboard input is pressed.
- **DistanceGrabController.cs**: Allows you to grab objects from a distance (useful for Oculus Go).
- **DragCamera.cs**: Allows camera rotation with the mouse in the editor.
- **FreeTeleportController.cs**: Allows a rig to teleport.
- **FreeTeleportationZone.cs**: Dictates an object the player can teleport onto.
- **GrabController.cs**: Allows controllers to pickup/throw objects.
- **ImpulseZeroGravity.cs**: Moves rigidbody based on desired input direction.
- **Interactable.cs**: Allows us to interact (detect, grab, etc) the object.
- **LaserPointer.cs**: Renders a line renderer from controller hand.
- **Reticle.cs**: Reticle which snaps to objects you're looking at.
- **ReticlePosition.cs**: Positions the reticle.
- **SetCorrectCameraHeight.cs**: Changes VR rig height based on hardware value.
- **VRCalloutController.cs**: Enables/disables object when interacting with it.
- **VrPointer.cs**: Raycast that shoots from a hand controller to detect interactables.
