// GENERATED AUTOMATICALLY FROM 'Assets/3_GameAssets/Global/PlayerInputsActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputsActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputsActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputsActions"",
    ""maps"": [
        {
            ""name"": ""Generic"",
            ""id"": ""cc0ad2d0-bd1f-422c-b9af-bd34ef652bcd"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""19d7310a-d9fc-42c9-811d-593fc2441ab7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""aeb7f9fd-f597-488b-9687-1a1a916fac2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""Value"",
                    ""id"": ""911161d6-a468-45f5-bcbb-45c6ab47f591"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""f43d33f3-fd45-43d0-b2fa-fb0faa57c15e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""323842a8-4365-4b34-8f57-276d99bdae35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""c1df4263-85fa-45cf-a45c-3eb603d67fe0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9969916b-0d05-49de-9bb3-96bf438e1dd6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectNextWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""af334d07-ab19-4643-9587-a54ae529ef53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectPreviousWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""5e0b9961-67ec-4251-8d38-64727e90ec18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectGrimoire"",
                    ""type"": ""Button"",
                    ""id"": ""3a883fa9-91be-4648-889d-64d666159e1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBow"",
                    ""type"": ""Button"",
                    ""id"": ""fd06b8d4-6c55-4ea6-aa7b-486cec020ad9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectMeleeWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""27b13ef0-10ba-4367-9c4b-ea0c6b64376f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""42e74cd5-8558-466a-b7e7-506a1922e42b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""dbac04cc-f5f0-457e-9c81-ef2ad6a65749"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""50aada6d-2580-4c4f-99ec-4dbe72637fac"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3eda4900-a918-4c37-9e17-cc53d965ef20"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""85b25988-6ca6-4f9a-9e4b-f5155d4bad17"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""be2190e0-286e-46b8-b669-af51a11d2778"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""079e7039-112c-4a1d-b767-df4d85c1dd90"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""074ee15a-8e26-4238-bf5a-1f4a44cb2ec1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dac7309-c893-4d94-bf63-fff960d0a7f6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=10,y=10)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aeaf02c-9ca1-40ca-ae29-74985c143d2e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5b518b9-6b9f-4f23-86ae-1ed40150b47a"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ea49731-e302-4236-a53f-1f3acbe673f4"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97916216-6e22-4f3e-a9aa-cc83db8c8a87"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8b30139-7ece-4871-bafe-ec5e1535f373"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f086238-1754-4ac1-94bf-96a6ede45039"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SecondaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47fdcb22-85c7-4e2e-b542-44af9bceeccb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""SecondaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d32f871-909c-44a3-a1fe-4cc6ad8d25f5"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86a2c6e6-f7c2-4c30-8a10-64bd6bdc489b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""664889c1-51bd-4201-85d3-4cf60dae26af"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SelectNextWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12e5c71a-57de-4bd7-8d11-d8a2912daf86"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""SelectNextWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc09945a-a144-48d0-b205-91fb488be6f6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectPreviousWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c35c6445-0d1e-4828-b298-48a939d3c80c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SelectGrimoire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2799e79-e132-40f6-a1b8-fc260c961e60"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""SelectGrimoire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a46f2169-2009-4be7-bc6d-f6ba11cf81ee"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SelectBow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2af51987-8735-4f88-9d43-fc06a6ee3a9b"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""SelectBow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""023ef842-98ba-4b80-aaa6-dd3565f9e59e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SelectMeleeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5fa7fe3-077b-43bc-97ed-19c34d84c7e2"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""SelectMeleeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""0167f467-2a7e-45f1-9643-3573f8a2c147"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""afabc476-5967-417c-a968-6542341e0858"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""db5aada0-48dc-4b08-9374-0161aa09bdcf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""7b928c87-4a19-4b9d-8c08-5622a224aef1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""e0e923c6-4324-4785-adc4-ee538e05dbe3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""0d245e2d-5139-4906-871b-4af48402b337"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""15f8bba1-1ce9-41ed-8d00-bcadfa6a5363"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextSection"",
                    ""type"": ""Button"",
                    ""id"": ""530ca813-4dd6-4edb-958a-991c67c853cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousSection"",
                    ""type"": ""Button"",
                    ""id"": ""ee896904-fce9-4166-876a-732da14cbefa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6c3fb8e5-ee25-400b-be92-2ec5a75c7758"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1576c170-3bbf-4bc1-936a-f2522fd33d7c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffbeba6e-eca7-4a1c-9946-c47f0a6dd0ee"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69a9abce-e97c-40d1-ad1c-9a589c76200c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd7e18a3-59a2-4bc7-a8e2-8fdcf141dd05"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcfc5d28-851b-480c-97e1-33cf4f0577e5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""434eaaa5-f4b6-44db-8629-5913b699c734"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4401fd32-2d0d-46e2-8a03-1f125b350bb3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3bd29c7-bc5b-48c7-a1c5-5e844c6e9a55"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7873aba-3040-41ee-beac-088adadd96ab"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16902f6a-5c08-45d3-986b-b73d45cc9877"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02ccf38d-0d39-4ac6-99f3-38f6f97cf289"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d489a261-0a62-41f9-ae17-9c3ffbda3942"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e86d4ea6-302d-4748-a8bd-dde5876be3cb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextSection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb97c4e7-fba2-42dc-bb6e-04e40ccff9cd"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextSection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36682b43-391e-450b-b66a-41da2d9c5461"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousSection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""158f1a20-4620-4622-b9dd-752711ad540c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousSection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cc587a8-9c55-486c-99d2-a0b18a1e59a9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f67d7102-c1bd-49fd-abac-44868e96bcbc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9058505a-27c8-4343-aeb5-0f24b0f0133d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""79bbd10f-c423-4862-92a9-c0520a1da1d6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""18998b04-336d-4be6-be9c-732138075e71"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""52eee92e-7c42-4527-8ed4-5a9d7afa0104"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""MouseAndKeyboard"",
            ""bindingGroup"": ""MouseAndKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Generic
        m_Generic = asset.FindActionMap("Generic", throwIfNotFound: true);
        m_Generic_Move = m_Generic.FindAction("Move", throwIfNotFound: true);
        m_Generic_Jump = m_Generic.FindAction("Jump", throwIfNotFound: true);
        m_Generic_LookAround = m_Generic.FindAction("LookAround", throwIfNotFound: true);
        m_Generic_Slide = m_Generic.FindAction("Slide", throwIfNotFound: true);
        m_Generic_PrimaryAttack = m_Generic.FindAction("PrimaryAttack", throwIfNotFound: true);
        m_Generic_SecondaryAttack = m_Generic.FindAction("SecondaryAttack", throwIfNotFound: true);
        m_Generic_Interact = m_Generic.FindAction("Interact", throwIfNotFound: true);
        m_Generic_SelectNextWeapon = m_Generic.FindAction("SelectNextWeapon", throwIfNotFound: true);
        m_Generic_SelectPreviousWeapon = m_Generic.FindAction("SelectPreviousWeapon", throwIfNotFound: true);
        m_Generic_SelectGrimoire = m_Generic.FindAction("SelectGrimoire", throwIfNotFound: true);
        m_Generic_SelectBow = m_Generic.FindAction("SelectBow", throwIfNotFound: true);
        m_Generic_SelectMeleeWeapon = m_Generic.FindAction("SelectMeleeWeapon", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Confirm = m_UI.FindAction("Confirm", throwIfNotFound: true);
        m_UI_Back = m_UI.FindAction("Back", throwIfNotFound: true);
        m_UI_MoveLeft = m_UI.FindAction("MoveLeft", throwIfNotFound: true);
        m_UI_MoveRight = m_UI.FindAction("MoveRight", throwIfNotFound: true);
        m_UI_MoveUp = m_UI.FindAction("MoveUp", throwIfNotFound: true);
        m_UI_MoveDown = m_UI.FindAction("MoveDown", throwIfNotFound: true);
        m_UI_NextSection = m_UI.FindAction("NextSection", throwIfNotFound: true);
        m_UI_PreviousSection = m_UI.FindAction("PreviousSection", throwIfNotFound: true);
        m_UI_Move = m_UI.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Generic
    private readonly InputActionMap m_Generic;
    private IGenericActions m_GenericActionsCallbackInterface;
    private readonly InputAction m_Generic_Move;
    private readonly InputAction m_Generic_Jump;
    private readonly InputAction m_Generic_LookAround;
    private readonly InputAction m_Generic_Slide;
    private readonly InputAction m_Generic_PrimaryAttack;
    private readonly InputAction m_Generic_SecondaryAttack;
    private readonly InputAction m_Generic_Interact;
    private readonly InputAction m_Generic_SelectNextWeapon;
    private readonly InputAction m_Generic_SelectPreviousWeapon;
    private readonly InputAction m_Generic_SelectGrimoire;
    private readonly InputAction m_Generic_SelectBow;
    private readonly InputAction m_Generic_SelectMeleeWeapon;
    public struct GenericActions
    {
        private @PlayerInputsActions m_Wrapper;
        public GenericActions(@PlayerInputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Generic_Move;
        public InputAction @Jump => m_Wrapper.m_Generic_Jump;
        public InputAction @LookAround => m_Wrapper.m_Generic_LookAround;
        public InputAction @Slide => m_Wrapper.m_Generic_Slide;
        public InputAction @PrimaryAttack => m_Wrapper.m_Generic_PrimaryAttack;
        public InputAction @SecondaryAttack => m_Wrapper.m_Generic_SecondaryAttack;
        public InputAction @Interact => m_Wrapper.m_Generic_Interact;
        public InputAction @SelectNextWeapon => m_Wrapper.m_Generic_SelectNextWeapon;
        public InputAction @SelectPreviousWeapon => m_Wrapper.m_Generic_SelectPreviousWeapon;
        public InputAction @SelectGrimoire => m_Wrapper.m_Generic_SelectGrimoire;
        public InputAction @SelectBow => m_Wrapper.m_Generic_SelectBow;
        public InputAction @SelectMeleeWeapon => m_Wrapper.m_Generic_SelectMeleeWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Generic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GenericActions set) { return set.Get(); }
        public void SetCallbacks(IGenericActions instance)
        {
            if (m_Wrapper.m_GenericActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnJump;
                @LookAround.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnLookAround;
                @Slide.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnSlide;
                @PrimaryAttack.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnPrimaryAttack;
                @SecondaryAttack.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnSecondaryAttack;
                @SecondaryAttack.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnSecondaryAttack;
                @SecondaryAttack.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnSecondaryAttack;
                @Interact.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnInteract;
                @SelectNextWeapon.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectNextWeapon;
                @SelectNextWeapon.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectNextWeapon;
                @SelectNextWeapon.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectNextWeapon;
                @SelectPreviousWeapon.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectPreviousWeapon;
                @SelectPreviousWeapon.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectPreviousWeapon;
                @SelectPreviousWeapon.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectPreviousWeapon;
                @SelectGrimoire.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectGrimoire;
                @SelectGrimoire.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectGrimoire;
                @SelectGrimoire.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectGrimoire;
                @SelectBow.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectBow;
                @SelectBow.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectBow;
                @SelectBow.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectBow;
                @SelectMeleeWeapon.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectMeleeWeapon;
                @SelectMeleeWeapon.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectMeleeWeapon;
                @SelectMeleeWeapon.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnSelectMeleeWeapon;
            }
            m_Wrapper.m_GenericActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
                @PrimaryAttack.started += instance.OnPrimaryAttack;
                @PrimaryAttack.performed += instance.OnPrimaryAttack;
                @PrimaryAttack.canceled += instance.OnPrimaryAttack;
                @SecondaryAttack.started += instance.OnSecondaryAttack;
                @SecondaryAttack.performed += instance.OnSecondaryAttack;
                @SecondaryAttack.canceled += instance.OnSecondaryAttack;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @SelectNextWeapon.started += instance.OnSelectNextWeapon;
                @SelectNextWeapon.performed += instance.OnSelectNextWeapon;
                @SelectNextWeapon.canceled += instance.OnSelectNextWeapon;
                @SelectPreviousWeapon.started += instance.OnSelectPreviousWeapon;
                @SelectPreviousWeapon.performed += instance.OnSelectPreviousWeapon;
                @SelectPreviousWeapon.canceled += instance.OnSelectPreviousWeapon;
                @SelectGrimoire.started += instance.OnSelectGrimoire;
                @SelectGrimoire.performed += instance.OnSelectGrimoire;
                @SelectGrimoire.canceled += instance.OnSelectGrimoire;
                @SelectBow.started += instance.OnSelectBow;
                @SelectBow.performed += instance.OnSelectBow;
                @SelectBow.canceled += instance.OnSelectBow;
                @SelectMeleeWeapon.started += instance.OnSelectMeleeWeapon;
                @SelectMeleeWeapon.performed += instance.OnSelectMeleeWeapon;
                @SelectMeleeWeapon.canceled += instance.OnSelectMeleeWeapon;
            }
        }
    }
    public GenericActions @Generic => new GenericActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Confirm;
    private readonly InputAction m_UI_Back;
    private readonly InputAction m_UI_MoveLeft;
    private readonly InputAction m_UI_MoveRight;
    private readonly InputAction m_UI_MoveUp;
    private readonly InputAction m_UI_MoveDown;
    private readonly InputAction m_UI_NextSection;
    private readonly InputAction m_UI_PreviousSection;
    private readonly InputAction m_UI_Move;
    public struct UIActions
    {
        private @PlayerInputsActions m_Wrapper;
        public UIActions(@PlayerInputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_UI_Confirm;
        public InputAction @Back => m_Wrapper.m_UI_Back;
        public InputAction @MoveLeft => m_Wrapper.m_UI_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_UI_MoveRight;
        public InputAction @MoveUp => m_Wrapper.m_UI_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_UI_MoveDown;
        public InputAction @NextSection => m_Wrapper.m_UI_NextSection;
        public InputAction @PreviousSection => m_Wrapper.m_UI_PreviousSection;
        public InputAction @Move => m_Wrapper.m_UI_Move;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Confirm.started -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
                @Back.started -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @MoveLeft.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveRight;
                @MoveUp.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveDown;
                @NextSection.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNextSection;
                @NextSection.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNextSection;
                @NextSection.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNextSection;
                @PreviousSection.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPreviousSection;
                @PreviousSection.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPreviousSection;
                @PreviousSection.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPreviousSection;
                @Move.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @NextSection.started += instance.OnNextSection;
                @NextSection.performed += instance.OnNextSection;
                @NextSection.canceled += instance.OnNextSection;
                @PreviousSection.started += instance.OnPreviousSection;
                @PreviousSection.performed += instance.OnPreviousSection;
                @PreviousSection.canceled += instance.OnPreviousSection;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_MouseAndKeyboardSchemeIndex = -1;
    public InputControlScheme MouseAndKeyboardScheme
    {
        get
        {
            if (m_MouseAndKeyboardSchemeIndex == -1) m_MouseAndKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseAndKeyboard");
            return asset.controlSchemes[m_MouseAndKeyboardSchemeIndex];
        }
    }
    public interface IGenericActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
        void OnPrimaryAttack(InputAction.CallbackContext context);
        void OnSecondaryAttack(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSelectNextWeapon(InputAction.CallbackContext context);
        void OnSelectPreviousWeapon(InputAction.CallbackContext context);
        void OnSelectGrimoire(InputAction.CallbackContext context);
        void OnSelectBow(InputAction.CallbackContext context);
        void OnSelectMeleeWeapon(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnNextSection(InputAction.CallbackContext context);
        void OnPreviousSection(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
