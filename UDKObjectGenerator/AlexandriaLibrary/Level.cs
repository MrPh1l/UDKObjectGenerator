using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using UELib;

namespace UDKObjectGenerator.AlexandriaLibrary
{
    public class Level
    {
        private const string rlCookedPCConsoleDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\rocketleague\\TAGame\\CookedPCConsole";
        private const string LAYER = "MainLevel";

        public string MapData { get; private set; }
        public string Kismet { get; private set; }
        public List<Package> Packages { get; set; } = new List<Package>();

        public Level(List<string> packageNames)
        {
            var kismetLoc = new Vector2(-42, -4198);

            foreach (string packageName in packageNames)
            {
                if (!File.Exists($"{rlCookedPCConsoleDir}\\{packageName}.upk"))
                    continue;

                var unrealPackage = UnrealLoader.LoadFullPackage($"{rlCookedPCConsoleDir}\\{packageName}.upk", FileAccess.Read);

                if (unrealPackage != null)
                {
                    if (kismetLoc.X > 1911)
                    {
                        kismetLoc.X = -42;
                        kismetLoc.Y += 200;
                    }

                    var package = new Package(packageName, kismetLoc, unrealPackage);

                    if (package.Materials.Any())
                    {
                        Packages.Add(package);
                        kismetLoc.X += 200;
                    }
                }
            }
        }

        public void Serialize()
        {
            SerializeMap();
            SerializeKismet();
        }

        private void SerializeMap()
        {
            Console.WriteLine("Level -> Starting data serialization.");
            MapData =
                "Begin Map\n" +
                    "\tBegin Level\n" +
                        // MainFloor
                        "\t\tBegin Actor Class=StaticMeshActor Name=StaticMeshActor_0 Archetype=StaticMeshActor'Engine.Default__StaticMeshActor'\n" +
                            "\t\t\tBegin Object name=StaticMeshComponent_144 class=StaticMeshComponent ObjName=StaticMeshComponent_0 Archetype=StaticMeshComponent'Engine.Default__StaticMeshActor:StaticMeshComponent0'\n" +
                                "\t\t\t\tStaticMesh=StaticMesh'Park_P.collisionmeshes.Plane32768'\n" +
                                "\t\t\t\tMaterials(0)=MaterialInstanceConstant'Park_P.stadium.Materials.ConcreteWall_MIC'\n" +
                                "\t\t\t\tReplacementPrimitive=none\n" +
                                "\t\t\t\tPreviewEnvironmentShadowing=147\n" +
                                "\t\t\t\tbUseAsOccluder=true\n" +
                                "\t\t\t\tbDisableAllRigidBody=False\n" +
                                "\t\t\t\tbAcceptsDynamicDecals=True\n" +
                                "\t\t\t\tBlockNonZeroExtent=false\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=true,Static=true)\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLocation=(X=0,Y=0,Z=0)\n" +
                            "\t\t\tDrawScale3D=(X=0.25,Y=0.25,Z=0.25)\n" +
                            "\t\t\tBlockRigidBody=True\n" +
                            "\t\t\tTag=\"StaticMeshActor\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=StaticMeshActor Name=StaticMeshActor_0 Archetype=StaticMeshActor'Engine.Default__StaticMeshActor'\n" +
                            "\t\t\tBegin Object name=StaticMeshComponent_144 class=StaticMeshComponent ObjName=StaticMeshComponent_0 Archetype=StaticMeshComponent'Engine.Default__StaticMeshActor:StaticMeshComponent0'\n" +
                                "\t\t\t\tStaticMesh=StaticMesh'Park_P.collisionmeshes.Plane32768'\n" +
                                "\t\t\t\tMaterials(0)=MaterialInstanceConstant'Park_P.stadium.Materials.ConcreteWall_MIC'\n" +
                                "\t\t\t\tReplacementPrimitive=none\n" +
                                "\t\t\t\tPreviewEnvironmentShadowing=147\n" +
                                "\t\t\t\tbUseAsOccluder=true\n" +
                                "\t\t\t\tbDisableAllRigidBody=False\n" +
                                "\t\t\t\tbAcceptsDynamicDecals=True\n" +
                                "\t\t\t\tBlockNonZeroExtent=false\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=true,Static=true)\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLocation=(X=-4096,Y=8191.75,Z=0)\n" +
                            "\t\t\tDrawScale3D=(X=0.25,Y=0.25,Z=0.25)\n" +
                            "\t\t\tBlockRigidBody=True\n" +
                            "\t\t\tTag=\"StaticMeshActor\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=StaticMeshActor Name=StaticMeshActor_0 Archetype=StaticMeshActor'Engine.Default__StaticMeshActor'\n" +
                            "\t\t\tBegin Object name=StaticMeshComponent_144 class=StaticMeshComponent ObjName=StaticMeshComponent_0 Archetype=StaticMeshComponent'Engine.Default__StaticMeshActor:StaticMeshComponent0'\n" +
                                "\t\t\t\tStaticMesh=StaticMesh'Park_P.collisionmeshes.Plane32768'\n" +
                                "\t\t\t\tMaterials(0)=MaterialInstanceConstant'Park_P.stadium.Materials.ConcreteWall_MIC'\n" +
                                "\t\t\t\tReplacementPrimitive=none\n" +
                                "\t\t\t\tPreviewEnvironmentShadowing=147\n" +
                                "\t\t\t\tbUseAsOccluder=true\n" +
                                "\t\t\t\tbDisableAllRigidBody=False\n" +
                                "\t\t\t\tbAcceptsDynamicDecals=True\n" +
                                "\t\t\t\tBlockNonZeroExtent=false\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=true,Static=true)\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLocation=(X=4096,Y=8191.75,Z=0)\n" +
                            "\t\t\tDrawScale3D=(X=0.25,Y=0.25,Z=0.25)\n" +
                            "\t\t\tBlockRigidBody=True\n" +
                            "\t\t\tTag=\"StaticMeshActor\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=StaticMeshActor Name=StaticMeshActor_0 Archetype=StaticMeshActor'Engine.Default__StaticMeshActor'\n" +
                            "\t\t\tBegin Object name=StaticMeshComponent_144 class=StaticMeshComponent ObjName=StaticMeshComponent_0 Archetype=StaticMeshComponent'Engine.Default__StaticMeshActor:StaticMeshComponent0'\n" +
                                "\t\t\t\tStaticMesh=StaticMesh'Park_P.collisionmeshes.Plane32768'\n" +
                                "\t\t\t\tMaterials(0)=MaterialInstanceConstant'Park_P.stadium.Materials.ConcreteWall_MIC'\n" +
                                "\t\t\t\tReplacementPrimitive=none\n" +
                                "\t\t\t\tPreviewEnvironmentShadowing=147\n" +
                                "\t\t\t\tbUseAsOccluder=true\n" +
                                "\t\t\t\tbDisableAllRigidBody=False\n" +
                                "\t\t\t\tbAcceptsDynamicDecals=True\n" +
                                "\t\t\t\tBlockNonZeroExtent=false\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=true,Static=true)\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLocation=(X=-4096,Y=16383.5,Z=0)\n" +
                            "\t\t\tDrawScale3D=(X=0.25,Y=0.25,Z=0.25)\n" +
                            "\t\t\tBlockRigidBody=True\n" +
                            "\t\t\tTag=\"StaticMeshActor\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=StaticMeshActor Name=StaticMeshActor_0 Archetype=StaticMeshActor'Engine.Default__StaticMeshActor'\n" +
                            "\t\t\tBegin Object name=StaticMeshComponent_144 class=StaticMeshComponent ObjName=StaticMeshComponent_0 Archetype=StaticMeshComponent'Engine.Default__StaticMeshActor:StaticMeshComponent0'\n" +
                                "\t\t\t\tStaticMesh=StaticMesh'Park_P.collisionmeshes.Plane32768'\n" +
                                "\t\t\t\tMaterials(0)=MaterialInstanceConstant'Park_P.stadium.Materials.ConcreteWall_MIC'\n" +
                                "\t\t\t\tReplacementPrimitive=none\n" +
                                "\t\t\t\tPreviewEnvironmentShadowing=147\n" +
                                "\t\t\t\tbUseAsOccluder=true\n" +
                                "\t\t\t\tbDisableAllRigidBody=False\n" +
                                "\t\t\t\tbAcceptsDynamicDecals=True\n" +
                                "\t\t\t\tBlockNonZeroExtent=false\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=true,Static=true)\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLocation=(X=4096,Y=16383.5,Z=0)\n" +
                            "\t\t\tDrawScale3D=(X=0.25,Y=0.25,Z=0.25)\n" +
                            "\t\t\tBlockRigidBody=True\n" +
                            "\t\t\tTag=\"StaticMeshActor\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                        "\t\tEnd Actor\n" +
                        // PlayerStart
                        "\t\tBegin Actor Class=PlayerStart_TA Name=PlayerStart_TA_0 Archetype=PlayerStart_TA'tagame.Default__PlayerStart_TA'\n" +
                            "\t\t\tLocation=(X=-96,Y=-1152,Z=83)\n" +
                            "\t\t\tRotation=(Pitch=0,Yaw=81920,Roll=0)\n" +
                            "\t\t\tDrawScale=4.0\n" +
                            "\t\t\tTag=\"PlayerStart_TA\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                        "\t\tEnd Actor\n" +
                        // PylonSoccar
                        "\t\tBegin Actor Class=Pylon_Soccar_TA Name=Pylon_Soccar_TA_0 Archetype=Pylon_Soccar_TA'tagame.Default__Pylon_Soccar_TA'\n" +
                            "\t\t\tBegin Object Class=NavigationMeshBase Name=NavigationMeshBase_9\n" +
                                "\t\t\t\tName=\"NavigationMeshBase_9\"\n" +
                                "\t\t\t\tObjectArchetype=NavigationMeshBase'Engine.Default__NavigationMeshBase'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=NavigationMeshBase Name=NavigationMeshBase_8\n" +
                                "\t\t\t\tName=\"NavigationMeshBase_8\"\n" +
                                "\t\t\t\tObjectArchetype=NavigationMeshBase'Engine.Default__NavigationMeshBase'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=Goal_TA Name=Goal_TA_0 ObjName=Goal_TA_4 Archetype=Goal_TA'tagame.Default__Pylon_Soccar_TA:Goal_TA_0'\n" +
                                "\t\t\t\tTeamNum=1\n" +
                                "\t\t\t\tScoreFX=FXActor_TA'Park_P.fxactors.Ball.BallExplosion_Blue_FXActor'\n" +
                                "\t\t\t\tName=\"Goal_TA_4\"\n" +
                                "\t\t\t\tObjectArchetype=Goal_TA'tagame.Default__Pylon_Soccar_TA:Goal_TA_0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=Goal_TA Name=Goal_TA_1 ObjName=Goal_TA_5 Archetype=Goal_TA'tagame.Default__Pylon_Soccar_TA:Goal_TA_1'\n" +
                                "\t\t\t\tTeamNum=1\n" +
                                "\t\t\t\tScoreFX=FXActor_TA'Park_P.fxactors.Ball.BallExplosion_Red_FXActor'\n" +
                                "\t\t\t\tName=\"Goal_TA_5\"\n" +
                                "\t\t\t\tObjectArchetype=Goal_TA'tagame.Default__Pylon_Soccar_TA:Goal_TA_1'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=DrawPylonRadiusComponent Name=DrawPylonRadius0 ObjName=DrawPylonRadiusComponent_0 Archetype=DrawPylonRadiusComponent'tagame.Default__Pylon_Soccar_TA:DrawPylonRadius0'\n" +
                                "\t\t\t\tSphereRadius=6559.097168\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"DrawPylonRadiusComponent_0\"\n" +
                                "\t\t\t\tObjectArchetype=DrawPylonRadiusComponent'tagame.Default__Pylon_Soccar_TA:DrawPylonRadius0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=NavMeshRenderingComponent Name=NavMeshRenderer ObjName=NavMeshRenderingComponent_0 Archetype=NavMeshRenderingComponent'tagame.Default__Pylon_Soccar_TA:NavMeshRenderer'\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"NavMeshRenderingComponent_0\"\n" +
                                "\t\t\t\tObjectArchetype=NavMeshRenderingComponent'tagame.Default__Pylon_Soccar_TA:NavMeshRenderer'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite3 ObjName=SpriteComponent_51 Archetype=SpriteComponent'tagame.Default__Pylon_Soccar_TA:Sprite3'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.BadPylon'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Navigation\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tHiddenEditor=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"SpriteComponent_51\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'tagame.Default__Pylon_Soccar_TA:Sprite3'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=CylinderComponent Name=CollisionCylinder ObjName=CylinderComponent_23 Archetype=CylinderComponent'tagame.Default__Pylon_Soccar_TA:CollisionCylinder'\n" +
                                "\t\t\t\tCollisionHeight=50.000000\n" +
                                "\t\t\t\tCollisionRadius=50.000000\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"CylinderComponent_23\"\n" +
                                "\t\t\t\tObjectArchetype=CylinderComponent'tagame.Default__Pylon_Soccar_TA:CollisionCylinder'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite ObjName=SpriteComponent_52 Archetype=SpriteComponent'tagame.Default__Pylon_Soccar_TA:Sprite'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.Pylon'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Navigation\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"SpriteComponent_52\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'tagame.Default__Pylon_Soccar_TA:Sprite'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite2 ObjName=SpriteComponent_53 Archetype=SpriteComponent'tagame.Default__Pylon_Soccar_TA:Sprite2'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.Bad'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Navigation\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tHiddenEditor=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tScale=0.250000\n" +
                                "\t\t\t\tName=\"SpriteComponent_53\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'tagame.Default__Pylon_Soccar_TA:Sprite2'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=ArrowComponent Name=Arrow ObjName=ArrowComponent_23 Archetype=ArrowComponent'tagame.Default__Pylon_Soccar_TA:Arrow'\n" +
                                "\t\t\t\tArrowColor=(B=255,G=200,R=150,A=255)\n" +
                                "\t\t\t\tArrowSize=0.500000\n" +
                                "\t\t\t\tbTreatAsASprite=True\n" +
                                "\t\t\t\tSpriteCategoryName=\"Navigation\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"ArrowComponent_23\"\n" +
                                "\t\t\t\tObjectArchetype=ArrowComponent'tagame.Default__Pylon_Soccar_TA:Arrow'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=PathRenderingComponent Name=PathRenderer ObjName=PathRenderingComponent_17 Archetype=PathRenderingComponent'tagame.Default__Pylon_Soccar_TA:PathRenderer'\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"PathRenderingComponent_17\"\n" +
                                "\t\t\t\tObjectArchetype=PathRenderingComponent'tagame.Default__Pylon_Soccar_TA:PathRenderer'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tFieldOrientation=(Pitch=0,Yaw=2982616,Roll=0)\n" +
                            "\t\t\tFieldSize=(X=11930.919922,Y=8141.853027,Z=1500.000000)\n" +
                            "\t\t\tFieldExtent=(X=5965.461914,Y=4070.927002,Z=750.000000)\n" +
                            "\t\t\tFieldCenter=(X=0.000000,Y=0.000000,Z=754.995667)\n" +
                            "\t\t\tGoals(0)=Goal_TA'Goal_TA_4'\n" +
                            "\t\t\tGoals(1)=Goal_TA'Goal_TA_5'\n" +
                            "\t\t\tSpawnPoints(0)=PlayerStart'PlayerStart_TA_0'\n" +
                            "\t\t\tGroundZ=4.995600\n" +
                            "\t\t\tExpansionRadius=6559.097168\n" +
                            "\t\t\tPylonRadiusPreview=DrawPylonRadiusComponent'DrawPylonRadiusComponent_0'\n" +
                            "\t\t\tRenderingComp=NavMeshRenderingComponent'NavMeshRenderingComponent_0'\n" +
                            "\t\t\tNavMeshGenerator=1\n" +
                            "\t\t\tbPathsChanged=True\n" +
                            "\t\t\tCylinderComponent=CylinderComponent'CylinderComponent_23'\n" +
                            "\t\t\tNavGuid=(A=1078492151,B=1295367495,C=365520009,D=-1606329644)\n" +
                            "\t\t\tComponents(0)=SpriteComponent'SpriteComponent_52'\n" +
                            "\t\t\tComponents(1)=SpriteComponent'SpriteComponent_53'\n" +
                            "\t\t\tComponents(2)=ArrowComponent'ArrowComponent_23'\n" +
                            "\t\t\tComponents(3)=CylinderComponent'CylinderComponent_23'\n" +
                            "\t\t\tComponents(4)=PathRenderingComponent'PathRenderingComponent_17'\n" +
                            "\t\t\tComponents(5)=NavMeshRenderingComponent'NavMeshRenderingComponent_0'\n" +
                            "\t\t\tComponents(6)=DrawPylonRadiusComponent'DrawPylonRadiusComponent_0'\n" +
                            "\t\t\tComponents(7)=SpriteComponent'SpriteComponent_51'\n" +
                            "\t\t\tLocation=(X=0.000000,Y=0.000000,Z=52.998821)\n" +
                            "\t\t\tBase=StaticMeshActor'StaticMeshActor_207'\n" +
                            "\t\t\tTag=\"Pylon_Soccar_TA\"\n" +
                            "\t\t\tRelativeLocation=(X=-4095.999512,Y=-4607.999512,Z=564.998779)\n" +
                            "\t\t\tCollisionComponent=CylinderComponent'CylinderComponent_23'\n" +
                            "\t\t\tName=\"Pylon_Soccar_TA_0\"\n" +
                            "\t\t\tObjectArchetype=Pylon_Soccar_TA'tagame.Default__Pylon_Soccar_TA'\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                        "\t\tEnd Actor\n" +
                        // LightmassImportanceVolume
                        "\t\tBegin Actor Class=LightmassImportanceVolume Name=LightmassImportanceVolume_0 Archetype=LightmassImportanceVolume'Engine.Default__LightmassImportanceVolume'\n" +
                            "\t\t\tBegin Object Class=BrushComponent Name=BrushComponent0 ObjName=BrushComponent_15 Archetype=BrushComponent'Engine.Default__LightmassImportanceVolume:BrushComponent0'\n" +
                                "\t\t\t\tBrush=Model'Model_7'\n" +
                                "\t\t\t\tBrushAggGeom=(ConvexElems=((VertexData=((X=2048.000000,Y=2048.000000,Z=-2048.000000),(X=2048.000000,Y=-2048.000000,Z=-2048.000000),(X=-2048.000000,Y=-2048.000000,Z=-2048.000000),(X=2048.000000,Y=2048.000000,Z=2048.000000),(X=-2048.000000,Y=-2048.000000,Z=2048.000000),(X=-2048.000000,Y=2048.000000,Z=-2048.000000),(X=2048.000000,Y=-2048.000000,Z=2048.000000),(X=-2048.000000,Y=2048.000000,Z=2048.000000)),PermutedVertexData=((W=2048.000000,X=2048.000000,Y=2048.000000,Z=-2048.000000),(W=2048.000000,X=2048.000000,Y=-2048.000000,Z=-2048.000000),(W=2048.000000,X=-2048.000000,Y=-2048.000000,Z=-2048.000000),(W=-2048.000000,X=-2048.000000,Y=-2048.000000,Z=2048.000000),(W=2048.000000,X=-2048.000000,Y=2048.000000,Z=-2048.000000),(W=2048.000000,X=2048.000000,Y=-2048.000000,Z=2048.000000)),FaceTriData=(0,2,1,0,5,2,1,3,0,1,6,3,4,1,2,4,6,1,5,4,2,5,7,4,7,0,3,7,5,0,6,7,3,6,4,7),EdgeDirections=((X=-1.000000,Y=0.000000,Z=0.000000),(X=0.000000,Y=-1.000000,Z=0.000000),(X=0.000000,Y=0.000000,Z=1.000000)),FaceNormalDirections=((X=0.000000,Y=-0.000000,Z=-1.000000),(X=1.000000,Y=0.000000,Z=0.000000),(X=0.000000,Y=-1.000000,Z=0.000000)),FacePlaneData=((W=2047.999878,X=0.000000,Y=-0.000000,Z=-1.000000),(W=2047.999878,X=1.000000,Y=0.000000,Z=0.000000),(W=2047.999878,X=0.000000,Y=-1.000000,Z=0.000000),(W=2047.999878,X=-1.000000,Y=0.000000,Z=0.000000),(W=2047.999878,X=-0.000000,Y=1.000000,Z=0.000000),(W=2047.999878,X=0.000000,Y=-0.000000,Z=1.000000)),ElemBox=(Min=(X=-2048.000000,Y=-2048.000000,Z=-2048.000000),Max=(X=2048.000000,Y=2048.000000,Z=2048.000000),IsValid=1))))\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tRBChannel=RBCC_Nothing\n" +
                                "\t\t\t\tbAcceptsLights=True\n" +
                                "\t\t\t\tbDisableAllRigidBody=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=True\n" +
                                "\t\t\t\tAlwaysLoadOnServer=True\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"BrushComponent_15\"\n" +
                                "\t\t\t\tObjectArchetype=BrushComponent'Engine.Default__LightmassImportanceVolume:BrushComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Brush Name=Model_7\n" +
                                "\t\t\t\tBegin PolyList\n" +
                                    "\t\t\t\t\tBegin Polygon Flags=3584 Link=0\n" +
                                        "\t\t\t\t\t\tOrigin\t-02048.000000,-02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tNormal\t-00001.000000,+00000.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureU +00000.000000,+00001.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureV +00000.000000,+00000.000000,-00001.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,-02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,-02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,+02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,+02048.000000,-02048.000000\n" +
                                    "\t\t\t\t\tEnd Polygon\n" +
                                    "\t\t\t\t\tBegin Polygon Flags=3584 Link=1\n" +
                                        "\t\t\t\t\t\tOrigin\t-02048.000000,+02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tNormal\t+00000.000000,+00001.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureU +00001.000000,-00000.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureV +00000.000000,+00000.000000,-00001.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,+02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,+02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,+02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,+02048.000000,-02048.000000\n" +
                                    "\t\t\t\t\tEnd Polygon\n" +
                                    "\t\t\t\t\tBegin Polygon Flags=3584 Link=2\n" +
                                        "\t\t\t\t\t\tOrigin\t+02048.000000,+02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tNormal\t+00001.000000,+00000.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureU +00000.000000,-00001.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureV +00000.000000,+00000.000000,-00001.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,+02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,+02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,-02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,-02048.000000,-02048.000000\n" +
                                    "\t\t\t\t\tEnd Polygon\n" +
                                    "\t\t\t\t\tBegin Polygon Flags=3584 Link=3\n" +
                                        "\t\t\t\t\t\tOrigin\t+02048.000000,-02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tNormal\t+00000.000000,-00001.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureU -00001.000000,-00000.000000,-00000.000000\n" +
                                        "\t\t\t\t\t\tTextureV +00000.000000,+00000.000000,-00001.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,-02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,-02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,-02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,-02048.000000,-02048.000000\n" +
                                    "\t\t\t\t\tEnd Polygon\n" +
                                    "\t\t\t\t\tBegin Polygon Flags=3584 Link=4\n" +
                                        "\t\t\t\t\t\tOrigin\t-02048.000000,+02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tNormal\t+00000.000000,+00000.000000,+00001.000000\n" +
                                        "\t\t\t\t\t\tTextureU +00001.000000,+00000.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureV +00000.000000,+00001.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,+02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,-02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,-02048.000000,+02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,+02048.000000,+02048.000000\n" +
                                    "\t\t\t\t\tEnd Polygon\n" +
                                    "\t\t\t\t\tBegin Polygon Flags=3584 Link=5\n" +
                                        "\t\t\t\t\t\tOrigin\t-02048.000000,-02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tNormal\t+00000.000000,+00000.000000,-00001.000000\n" +
                                        "\t\t\t\t\t\tTextureU +00001.000000,+00000.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tTextureV +00000.000000,-00001.000000,+00000.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,-02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t-02048.000000,+02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,+02048.000000,-02048.000000\n" +
                                        "\t\t\t\t\t\tVertex\t+02048.000000,-02048.000000,-02048.000000\n" +
                                    "\t\t\t\t\tEnd Polygon\n" +
                                "\t\t\t\tEnd PolyList\n" +
                            "\t\t\tEnd Brush\n" +
                            "\t\t\tBrush=Model'Model_7'\n" +
                            "\t\t\tBrushComponent=BrushComponent'BrushComponent_15'\n" +
                            "\t\t\tComponents(0)=BrushComponent'BrushComponent_15'\n" +
                            "\t\t\tLocation=(X=0.000000,Y=0.000000,Z=2048.000000)\n" +
                            "\t\t\tTag=\"LightmassImportanceVolume\"\n" +
                            "\t\t\tCollisionComponent=BrushComponent'BrushComponent_15'\n" +
                            "\t\t\tName=\"LightmassImportanceVolume_0\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                            "\t\t\tObjectArchetype=LightmassImportanceVolume'Engine.Default__LightmassImportanceVolume'\n" +
                        "\t\tEnd Actor\n" +
                        // Directional lights
                        "\t\tBegin Actor Class=DirectionalLight Name=DirectionalLight_7 Archetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                            "\t\t\tBegin Object Class=DirectionalLightComponent Name=DirectionalLightComponent0 ObjName=DirectionalLightComponent_139 Archetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                                "\t\t\t\tLightmassSettings=(LightSourceAngle=1.000000)\n" +
                                "\t\t\t\tLightGuid=(A=1974537102,B=1242236163,C=-562869359,D=-1881575166)\n" +
                                "\t\t\t\tLightmapGuid=(A=1148423730,B=1339517822,C=-1415533915,D=-1437462784)\n" +
                                "\t\t\t\tBrightness=1.500000\n" +
                                "\t\t\t\tUseDirectLightMap=True\n" +
                                "\t\t\t\tbHasLightEverBeenBuiltIntoLightMap=True\n" +
                                "\t\t\t\tModShadowColor=(R=0.342697,G=0.342697,B=0.342697,A=1.000000)\n" +
                                "\t\t\t\tShadowFilterQuality=SFQ_Medium\n" +
                                "\t\t\t\tReflectionSpecularBrightness=1.000000\n" +
                                "\t\t\t\tName=\"DirectionalLightComponent_139\"\n" +
                                "\t\t\t\tObjectArchetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite ObjName=SpriteComponent_96 Archetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.LightIcons.Light_Directional_Stationary_UserSelected'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tScale=0.250000\n" +
                                "\t\t\t\tName=\"SpriteComponent_96\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=ArrowComponent Name=ArrowComponent0 ObjName=ArrowComponent_46 Archetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                                "\t\t\t\tArrowColor=(B=255,G=200,R=150,A=255)\n" +
                                "\t\t\t\tbTreatAsASprite=True\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"ArrowComponent_46\"\n" +
                                "\t\t\t\tObjectArchetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLightComponent=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(0)=SpriteComponent'SpriteComponent_96'\n" +
                            "\t\t\tComponents(1)=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(2)=ArrowComponent'ArrowComponent_46'\n" +
                            "\t\t\tLocation=(X=-190.939774,Y=247.148331,Z=2809.342285)\n" +
                            "\t\t\tRotation=(Pitch=-16384,Yaw=64922,Roll=-32152)\n" +
                            "\t\t\tDrawScale=5.000000\n" +
                            "\t\t\tTag=\"DirectionalLight\"\n" +
                            "\t\t\tName=\"DirectionalLight_7\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                            "\t\t\tObjectArchetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=DirectionalLight Name=DirectionalLight_4 Archetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                            "\t\t\tBegin Object Class=DirectionalLightComponent Name=DirectionalLightComponent0 ObjName=DirectionalLightComponent_139 Archetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                                "\t\t\t\tLightmassSettings=(LightSourceAngle=1.000000)\n" +
                                "\t\t\t\tLightGuid=(A=-2029805500,B=1263175680,C=-2040523590,D=-349259803)\n" +
                                "\t\t\t\tLightmapGuid=(A=680280073,B=1083954506,C=1005299390,D=1166068456)\n" +
                                "\t\t\t\tBrightness=0.500000\n" +
                                "\t\t\t\tCastShadows=False\n" +
                                "\t\t\t\tCastStaticShadows=False\n" +
                                "\t\t\t\tCastDynamicShadows=False\n" +
                                "\t\t\t\tbCastCompositeShadow=False\n" +
                                "\t\t\t\tbAffectCompositeShadowDirection=False\n" +
                                "\t\t\t\tUseDirectLightMap=True\n" +
                                "\t\t\t\tbHasLightEverBeenBuiltIntoLightMap=True\n" +
                                "\t\t\t\tModShadowColor=(R=1.000000,G=1.000000,B=1.000000,A=1.000000)\n" +
                                "\t\t\t\tShadowFilterQuality=SFQ_Medium\n" +
                                "\t\t\t\tReflectionSpecularBrightness=0.100000\n" +
                                "\t\t\t\tName=\"DirectionalLightComponent_139\"\n" +
                                "\t\t\t\tObjectArchetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite ObjName=SpriteComponent_94 Archetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.LightIcons.Light_Directional_Stationary_UserSelected'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tScale=0.250000\n" +
                                "\t\t\t\tName=\"SpriteComponent_94\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=ArrowComponent Name=ArrowComponent0 ObjName=ArrowComponent_44 Archetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                                "\t\t\t\tArrowColor=(B=255,G=200,R=150,A=255)\n" +
                                "\t\t\t\tbTreatAsASprite=True\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"ArrowComponent_44\"\n" +
                                "\t\t\t\tObjectArchetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLightComponent=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(0)=SpriteComponent'SpriteComponent_94'\n" +
                            "\t\t\tComponents(1)=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(2)=ArrowComponent'ArrowComponent_44'\n" +
                            "\t\t\tLocation=(X=245.178040,Y=234.901413,Z=2814.524170)\n" +
                            "\t\t\tRotation=(Pitch=88,Yaw=-262176,Roll=-180180)\n" +
                            "\t\t\tDrawScale=5.000000\n" +
                            "\t\t\tTag=\"DirectionalLight\"\n" +
                            "\t\t\tName=\"DirectionalLight_4\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                            "\t\t\tObjectArchetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=DirectionalLight Name=DirectionalLight_5 Archetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                            "\t\t\tBegin Object Class=DirectionalLightComponent Name=DirectionalLightComponent0 ObjName=DirectionalLightComponent_139 Archetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                                "\t\t\t\tLightmassSettings=(LightSourceAngle=1.000000)\n" +
                                "\t\t\t\tLightGuid=(A=945459480,B=1121956006,C=21559441,D=2122124596)\n" +
                                "\t\t\t\tLightmapGuid=(A=-1100823769,B=1293956127,C=-117996918,D=-1055801020)\n" +
                                "\t\t\t\tBrightness=0.500000\n" +
                                "\t\t\t\tCastShadows=False\n" +
                                "\t\t\t\tCastStaticShadows=False\n" +
                                "\t\t\t\tCastDynamicShadows=False\n" +
                                "\t\t\t\tbCastCompositeShadow=False\n" +
                                "\t\t\t\tbAffectCompositeShadowDirection=False\n" +
                                "\t\t\t\tUseDirectLightMap=True\n" +
                                "\t\t\t\tbHasLightEverBeenBuiltIntoLightMap=True\n" +
                                "\t\t\t\tModShadowColor=(R=1.000000,G=1.000000,B=1.000000,A=1.000000)\n" +
                                "\t\t\t\tShadowFilterQuality=SFQ_Medium\n" +
                                "\t\t\t\tReflectionSpecularBrightness=0.100000\n" +
                                "\t\t\t\tName=\"DirectionalLightComponent_139\"\n" +
                                "\t\t\t\tObjectArchetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite ObjName=SpriteComponent_95 Archetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.LightIcons.Light_Directional_Stationary_UserSelected'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tScale=0.250000\n" +
                                "\t\t\t\tName=\"SpriteComponent_95\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=ArrowComponent Name=ArrowComponent0 ObjName=ArrowComponent_45 Archetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                                "\t\t\t\tArrowColor=(B=255,G=200,R=150,A=255)\n" +
                                "\t\t\t\tbTreatAsASprite=True\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"ArrowComponent_45\"\n" +
                                "\t\t\t\tObjectArchetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLightComponent=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(0)=SpriteComponent'SpriteComponent_95'\n" +
                            "\t\t\tComponents(1)=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(2)=ArrowComponent'ArrowComponent_45'\n" +
                            "\t\t\tLocation=(X=-602.920349,Y=221.447830,Z=2807.521729)\n" +
                            "\t\t\tRotation=(Pitch=-296,Yaw=-229448,Roll=-180816)\n" +
                            "\t\t\tDrawScale=5.000000\n" +
                            "\t\t\tTag=\"DirectionalLight\"\n" +
                            "\t\t\tName=\"DirectionalLight_5\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                            "\t\t\tObjectArchetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=DirectionalLight Name=DirectionalLight_3 Archetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                            "\t\t\tBegin Object Class=DirectionalLightComponent Name=DirectionalLightComponent0 ObjName=DirectionalLightComponent_139 Archetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                                "\t\t\t\tLightmassSettings=(LightSourceAngle=1.000000)\n" +
                                "\t\t\t\tLightGuid=(A=1170123550,B=1238259354,C=66064297,D=-1049929982)\n" +
                                "\t\t\t\tLightmapGuid=(A=-2125469594,B=1254206472,C=309101462,D=-1259252204)\n" +
                                "\t\t\t\tBrightness=0.300000\n" +
                                "\t\t\t\tLightColor=(B=227,G=92,R=91,A=0)\n" +
                                "\t\t\t\tCastShadows=False\n" +
                                "\t\t\t\tCastStaticShadows=False\n" +
                                "\t\t\t\tCastDynamicShadows=False\n" +
                                "\t\t\t\tbCastCompositeShadow=False\n" +
                                "\t\t\t\tbAffectCompositeShadowDirection=False\n" +
                                "\t\t\t\tUseDirectLightMap=True\n" +
                                "\t\t\t\tbHasLightEverBeenBuiltIntoLightMap=True\n" +
                                "\t\t\t\tModShadowColor=(R=1.000000,G=1.000000,B=1.000000,A=1.000000)\n" +
                                "\t\t\t\tShadowFilterQuality=SFQ_Medium\n" +
                                "\t\t\t\tReflectionSpecularBrightness=0.100000\n" +
                                "\t\t\t\tName=\"DirectionalLightComponent_139\"\n" +
                                "\t\t\t\tObjectArchetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite ObjName=SpriteComponent_93 Archetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.LightIcons.Light_Directional_Stationary_UserSelected'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tScale=0.250000\n" +
                                "\t\t\t\tName=\"SpriteComponent_93\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=ArrowComponent Name=ArrowComponent0 ObjName=ArrowComponent_43 Archetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                                "\t\t\t\tArrowColor=(B=255,G=200,R=150,A=255)\n" +
                                "\t\t\t\tbTreatAsASprite=True\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"ArrowComponent_43\"\n" +
                                "\t\t\t\tObjectArchetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLightComponent=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(0)=SpriteComponent'SpriteComponent_93'\n" +
                            "\t\t\tComponents(1)=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(2)=ArrowComponent'ArrowComponent_43'\n" +
                            "\t\t\tLocation=(X=-187.445724,Y=628.772461,Z=2836.074951)\n" +
                            "\t\t\tRotation=(Pitch=-72,Yaw=-245880,Roll=-180464)\n" +
                            "\t\t\tDrawScale=5.000000\n" +
                            "\t\t\tTag=\"DirectionalLight\"\n" +
                            "\t\t\tName=\"DirectionalLight_3\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                            "\t\t\tObjectArchetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=DirectionalLight Name=DirectionalLight_0 Archetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                            "\t\t\tBegin Object Class=DirectionalLightComponent Name=DirectionalLightComponent0 ObjName=DirectionalLightComponent_139 Archetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                                "\t\t\t\tLightmassSettings=(LightSourceAngle=1.000000)\n" +
                                "\t\t\t\tLightGuid=(A=-288225848,B=1277146752,C=-1706768236,D=1647195557)\n" +
                                "\t\t\t\tLightmapGuid=(A=1400752188,B=1218418976,C=1334578356,D=-993851432)\n" +
                                "\t\t\t\tBrightness=0.300000\n" +
                                "\t\t\t\tLightColor=(B=85,G=140,R=255,A=0)\n" +
                                "\t\t\t\tCastShadows=False\n" +
                                "\t\t\t\tCastStaticShadows=False\n" +
                                "\t\t\t\tCastDynamicShadows=False\n" +
                                "\t\t\t\tbCastCompositeShadow=False\n" +
                                "\t\t\t\tbAffectCompositeShadowDirection=False\n" +
                                "\t\t\t\tUseDirectLightMap=True\n" +
                                "\t\t\t\tbHasLightEverBeenBuiltIntoLightMap=True\n" +
                                "\t\t\t\tModShadowColor=(R=1.000000,G=1.000000,B=1.000000,A=1.000000)\n" +
                                "\t\t\t\tShadowFilterQuality=SFQ_Medium\n" +
                                "\t\t\t\tReflectionSpecularBrightness=0.100000\n" +
                                "\t\t\t\tName=\"DirectionalLightComponent_139\"\n" +
                                "\t\t\t\tObjectArchetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite ObjName=SpriteComponent_91 Archetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.LightIcons.Light_Directional_Stationary_UserSelected'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tScale=0.250000\n" +
                                "\t\t\t\tName=\"SpriteComponent_91\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=ArrowComponent Name=ArrowComponent0 ObjName=ArrowComponent_41 Archetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                                "\t\t\t\tArrowColor=(B=255,G=200,R=150,A=255)\n" +
                                "\t\t\t\tbTreatAsASprite=True\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"ArrowComponent_41\"\n" +
                                "\t\t\t\tObjectArchetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLightComponent=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(0)=SpriteComponent'SpriteComponent_91'\n" +
                            "\t\t\tComponents(1)=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(2)=ArrowComponent'ArrowComponent_41'\n" +
                            "\t\t\tLocation=(X=-168.757919,Y=-216.107895,Z=2820.677979)\n" +
                            "\t\t\tRotation=(Pitch=-652,Yaw=-213028,Roll=-181432)\n" +
                            "\t\t\tDrawScale=5.000000\n" +
                            "\t\t\tTag=\"DirectionalLight\"\n" +
                            "\t\t\tName=\"DirectionalLight_0\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                            "\t\t\tObjectArchetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                        "\t\tEnd Actor\n" +
                        "\t\tBegin Actor Class=DirectionalLight Name=DirectionalLight_2 Archetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                            "\t\t\tBegin Object Class=DirectionalLightComponent Name=DirectionalLightComponent0 ObjName=DirectionalLightComponent_139 Archetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                                "\t\t\t\tLightmassSettings=(LightSourceAngle=1.000000)\n" +
                                "\t\t\t\tLightGuid=(A=622973906,B=1181703487,C=-1542654794,D=-1057741583)\n" +
                                "\t\t\t\tLightmapGuid=(A=-2012435994,B=1118342035,C=70728619,D=-2081510298)\n" +
                                "\t\t\t\tBrightness=0.300000\n" +
                                "\t\t\t\tCastShadows=False\n" +
                                "\t\t\t\tCastStaticShadows=False\n" +
                                "\t\t\t\tCastDynamicShadows=False\n" +
                                "\t\t\t\tbCastCompositeShadow=False\n" +
                                "\t\t\t\tbAffectCompositeShadowDirection=False\n" +
                                "\t\t\t\tUseDirectLightMap=True\n" +
                                "\t\t\t\tbHasLightEverBeenBuiltIntoLightMap=True\n" +
                                "\t\t\t\tModShadowColor=(R=1.000000,G=1.000000,B=1.000000,A=1.000000)\n" +
                                "\t\t\t\tShadowFilterQuality=SFQ_Medium\n" +
                                "\t\t\t\tReflectionSpecularBrightness=1.000000\n" +
                                "\t\t\t\tName=\"DirectionalLightComponent_139\"\n" +
                                "\t\t\t\tObjectArchetype=DirectionalLightComponent'Engine.Default__DirectionalLight:DirectionalLightComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite ObjName=SpriteComponent_92 Archetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                                "\t\t\t\tSprite=Texture2D'EditorResources.LightIcons.Light_Directional_Stationary_UserSelected'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tScale=0.250000\n" +
                                "\t\t\t\tName=\"SpriteComponent_92\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'Engine.Default__DirectionalLight:Sprite'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=ArrowComponent Name=ArrowComponent0 ObjName=ArrowComponent_42 Archetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                                "\t\t\t\tArrowColor=(B=255,G=200,R=150,A=255)\n" +
                                "\t\t\t\tbTreatAsASprite=True\n" +
                                "\t\t\t\tSpriteCategoryName=\"Lighting\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"ArrowComponent_42\"\n" +
                                "\t\t\t\tObjectArchetype=ArrowComponent'Engine.Default__DirectionalLight:ArrowComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tLightComponent=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(0)=SpriteComponent'SpriteComponent_92'\n" +
                            "\t\t\tComponents(1)=DirectionalLightComponent'DirectionalLightComponent_139'\n" +
                            "\t\t\tComponents(2)=ArrowComponent'ArrowComponent_42'\n" +
                            "\t\t\tLocation=(X=-190.939789,Y=247.151382,Z=3270.101074)\n" +
                            "\t\t\tRotation=(Pitch=16384,Yaw=32791,Roll=-65516)\n" +
                            "\t\t\tDrawScale=5.000000\n" +
                            "\t\t\tTag=\"DirectionalLight\"\n" +
                            "\t\t\tName=\"DirectionalLight_2\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                            "\t\t\tObjectArchetype=DirectionalLight'Engine.Default__DirectionalLight'\n" +
                        "\t\tEnd Actor\n" +
                        // ExponentialHeightFog
                        "\t\tBegin Actor Class=ExponentialHeightFog Name=ExponentialHeightFog_0 Archetype=ExponentialHeightFog'Engine.Default__ExponentialHeightFog'\n" +
                            "\t\t\tBegin Object Class=ExponentialHeightFogComponent Name=HeightFogComponent0 ObjName=ExponentialHeightFogComponent_0 Archetype=ExponentialHeightFogComponent'Engine.Default__ExponentialHeightFog:HeightFogComponent0'\n" +
                                "\t\t\t\tFogHeight=5256.994141\n" +
                                "\t\t\t\tStartDistance=1024.000000\n" +
                                "\t\t\t\tLightTerminatorAngle=50.000000\n" +
                                "\t\t\t\tOppositeLightBrightness=0.700000\n" +
                                "\t\t\t\tOppositeLightColor=(B=255,G=219,R=191,A=0)\n" +
                                "\t\t\t\tLightInscatteringBrightness=0.700000\n" +
                                "\t\t\t\tLightInscatteringColor=(B=184,G=222,R=255,A=0)\n" +
                                "\t\t\t\tName=\"ExponentialHeightFogComponent_0\"\n" +
                                "\t\t\t\tObjectArchetype=ExponentialHeightFogComponent'Engine.Default__ExponentialHeightFog:HeightFogComponent0'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tBegin Object Class=SpriteComponent Name=Sprite ObjName=SpriteComponent_97 Archetype=SpriteComponent'Engine.Default__ExponentialHeightFog:Sprite'\n" +
                                "\t\t\t\tSpriteCategoryName=\"Fog\"\n" +
                                "\t\t\t\tReplacementPrimitive=None\n" +
                                "\t\t\t\tHiddenGame=True\n" +
                                "\t\t\t\tAlwaysLoadOnClient=False\n" +
                                "\t\t\t\tAlwaysLoadOnServer=False\n" +
                                "\t\t\t\tLightingChannels=(bInitialized=True,Dynamic=True)\n" +
                                "\t\t\t\tName=\"SpriteComponent_97\"\n" +
                                "\t\t\t\tObjectArchetype=SpriteComponent'Engine.Default__ExponentialHeightFog:Sprite'\n" +
                            "\t\t\tEnd Object\n" +
                            "\t\t\tComponent=ExponentialHeightFogComponent'ExponentialHeightFogComponent_0'\n" +
                            "\t\t\tComponents(0)=SpriteComponent'SpriteComponent_97'\n" +
                            "\t\t\tComponents(1)=ExponentialHeightFogComponent'ExponentialHeightFogComponent_0'\n" +
                            "\t\t\tLocation=(X=-160.000000,Y=1184.000244,Z=5256.994141)\n" +
                            "\t\t\tTag=\"ExponentialHeightFog\"\n" +
                            "\t\t\tName=\"ExponentialHeightFog_0\"\n" +
                            $"\t\t\tLayer=\"{LAYER}\"\n" +
                            "\t\t\tObjectArchetype=ExponentialHeightFog'Engine.Default__ExponentialHeightFog'\n" +
                        "\t\tEnd Actor\n";

            // Packages
            //Packages.ForEach(p => Data += p.GetSerialized());

            MapData +=     "\tEnd Level\n" +
                    "\tBegin Surface\n" +
                    "\tEnd Surface\n" +
                "End Map";
            Console.WriteLine("Level -> Data serialization done.");
        }

        private void SerializeKismet()
        {
            Console.WriteLine("Level -> Starting kismet serialization.");
            Kismet =
               "Begin Object Class=SeqVar_ObjectList Name=SeqVar_ObjectList_45\n" +
                    "\tVarName=\"CubeMaterialList\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4752\n" +
                    "\tObjPosY=-5848\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_ObjectList_45\"\n" +
                    "\tObjectArchetype=SeqVar_ObjectList'Engine.Default__SeqVar_ObjectList'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_1\n" +
                    $"\tIntValue={Packages.Count}\n" +
                    "\tVarName=\"MaterialPackageCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4584\n" +
                    "\tObjPosY=-5848\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_1\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_2\n" +
                    "\tIntValue=1\n" +
                    "\tVarName=\"MaterialPackageIndex\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4264\n" +
                    "\tObjPosY=-5848\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_2\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_3\n" +
                    "\tVarName=\"CubeListCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4424\n" +
                    "\tObjPosY=-5848\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_3\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Object Name=SeqVar_Object_0\n" +
                    "\tVarName=\"LibraryUI\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4056\n" +
                    "\tObjPosY=-5848\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Object_0\"\n" +
                    "\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_String Name=SeqVar_String_5\n" +
                    "\tVarName=\"PreviousMaterialPackage\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3872\n" +
                    "\tObjPosY=-5840\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_String_5\"\n" +
                    "\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_String Name=SeqVar_String_15\n" +
                    "\tVarName=\"NextMaterialPackage\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3512\n" +
                    "\tObjPosY=-5840\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_String_15\"\n" +
                    "\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_String Name=SeqVar_String_1\n" +
                    "\tVarName=\"CurrentMaterialPackage\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3688\n" +
                    "\tObjPosY=-5840\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_String_1\"\n" +
                    "\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                "End Object\n" +
                "Begin Object Class=SeqEvent_LevelLoaded Name=SeqEvent_LevelLoaded_0\n" +
                    "\tMaxWidth=136\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=GFxAction_OpenMovie'GFxAction_OpenMovie_1')),DrawY=-5187,OverrideDelta=14)\n" +
                    "\tOutputLinks(1)=(DrawY=-5166,OverrideDelta=35)\n" +
                    "\tOutputLinks(2)=(DrawY=-5145,OverrideDelta=56)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4784\n" +
                    "\tObjPosY=-5256\n" +
                    "\tDrawWidth=137\n" +
                    "\tName=\"SeqEvent_LevelLoaded_0\"\n" +
                    "\tObjectArchetype=SeqEvent_LevelLoaded'Engine.Default__SeqEvent_LevelLoaded'\n" +
                "End Object\n" +
                "Begin Object Class=GFxAction_OpenMovie Name=GFxAction_OpenMovie_1\n" +
                    "\tMovie=SwfMovie'LibraryUI'\n" +
                    "\tInputLinks(0)=(DrawY=-5178,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_1')),DrawY=-5188,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(DrawY=-5168,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(DrawX=-4503,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(DrawX=-4431,OverrideDelta=98)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_0'),DrawX=-4369,OverrideDelta=161)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4552\n" +
                    "\tObjPosY=-5224\n" +
                    "\tDrawWidth=222\n" +
                    "\tDrawHeight=101\n" +
                    "\tName=\"GFxAction_OpenMovie_1\"\n" +
                    "\tObjectArchetype=GFxAction_OpenMovie'GFxUI.Default__GFxAction_OpenMovie'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_0\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Object'\n" +
                    "\tFindVarName=\"LibraryUI\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4392\n" +
                    "\tObjPosY=-5088\n" +
                    "\tObjColor=(B=255,G=0,R=255,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_0\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ActivateRemoteEvent Name=SeqAct_ActivateRemoteEvent_1\n" +
                    "\tEventName=\"HideAllCubes\"\n" +
                    "\tInputLinks(0)=(DrawY=-4830,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_4')),DrawY=-4830,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-4541,OverrideDelta=99)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4672\n" +
                    "\tObjPosY=-4864\n" +
                    "\tDrawWidth=261\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ActivateRemoteEvent_1\"\n" +
                    "\tObjectArchetype=SeqAct_ActivateRemoteEvent'Engine.Default__SeqAct_ActivateRemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ActivateRemoteEvent Name=SeqAct_ActivateRemoteEvent_4\n" +
                    "\tEventName=\"InitObjectList\"\n" +
                    "\tInputLinks(0)=(DrawY=-4830,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Delay'SeqAct_Delay_2'),(LinkedOp=SeqAct_AddGameBall_TA'SeqAct_AddGameBall_TA_0',InputLinkIdx=2),(LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_9'),(LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_10'),(LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_11'),(LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_3')),DrawY=-4830,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-4197,OverrideDelta=99)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4328\n" +
                    "\tObjPosY=-4864\n" +
                    "\tObjComment=\"Adds each cube to cube object list\"\n" +
                    "\tDrawWidth=267\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ActivateRemoteEvent_4\"\n" +
                    "\tObjectArchetype=SeqAct_ActivateRemoteEvent'Engine.Default__SeqAct_ActivateRemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_Delay Name=SeqAct_Delay_2\n" +
                    "\tInputLinks(0)=(DrawY=-4827,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-4806,OverrideDelta=35)\n" +
                    "\tInputLinks(2)=(DrawY=-4785,OverrideDelta=56)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ModifyObjectList'SeqAct_ModifyObjectList_0',InputLinkIdx=1)),DrawY=-4822,OverrideDelta=19)\n" +
                    "\tOutputLinks(1)=(DrawY=-4790,OverrideDelta=51)\n" +
                    "\tVariableLinks(0)=(DrawX=-3908,OverrideDelta=25)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3960\n" +
                    "\tObjPosY=-4864\n" +
                    "\tDrawWidth=106\n" +
                    "\tDrawHeight=109\n" +
                    "\tName=\"SeqAct_Delay_2\"\n" +
                    "\tObjectArchetype=SeqAct_Delay'Engine.Default__SeqAct_Delay'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AddGameBall_TA Name=SeqAct_AddGameBall_TA_0\n" +
                    "\tInputLinks(0)=(DrawY=-5186,OverrideDelta=15)\n" +
                    "\tInputLinks(1)=(DrawY=-5164,OverrideDelta=37)\n" +
                    "\tInputLinks(2)=(DrawY=-5142,ActivateDelay=0.100000,OverrideDelta=59)\n" +
                    "\tInputLinks(3)=(DrawY=-5120,OverrideDelta=81)\n" +
                    "\tInputLinks(4)=(DrawY=-5098,OverrideDelta=103)\n" +
                    "\tOutputLinks(0)=(DrawY=-5184,OverrideDelta=17)\n" +
                    "\tOutputLinks(1)=(DrawY=-5156,OverrideDelta=45)\n" +
                    "\tOutputLinks(2)=(DrawY=-5128,OverrideDelta=73)\n" +
                    "\tOutputLinks(3)=(DrawY=-5100,OverrideDelta=101)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_3'),DrawX=-3984,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(DrawX=-3903,OverrideDelta=96)\n" +
                    "\tVariableLinks(2)=(DrawX=-3824,OverrideDelta=178)\n" +
                    "\tVariableLinks(3)=(DrawX=-3757,OverrideDelta=254)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4032\n" +
                    "\tObjPosY=-5224\n" +
                    "\tDrawWidth=313\n" +
                    "\tDrawHeight=173\n" +
                    "\tName=\"SeqAct_AddGameBall_TA_0\"\n" +
                    "\tObjectArchetype=SeqAct_AddGameBall_TA'tagame.Default__SeqAct_AddGameBall_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Player Name=SeqVar_Player_3\n" +
                    "\tbAllPlayers=False\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3992\n" +
                    "\tObjPosY=-5008\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Player_3\"\n" +
                    "\tObjectArchetype=SeqVar_Player'Engine.Default__SeqVar_Player'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ModifyObjectList Name=SeqAct_ModifyObjectList_0\n" +
                    "\tInputLinks(0)=(DrawY=-4843,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-4822,OverrideDelta=35)\n" +
                    "\tInputLinks(2)=(DrawY=-4801,OverrideDelta=56)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_5')),DrawY=-4822,OverrideDelta=35)\n" +
                    "\tVariableLinks(0)=(DrawX=-3626,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_2'),DrawX=-3566,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_3'),DrawX=-3485,OverrideDelta=137)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3664\n" +
                    "\tObjPosY=-4880\n" +
                    "\tDrawWidth=237\n" +
                    "\tDrawHeight=125\n" +
                    "\tName=\"SeqAct_ModifyObjectList_0\"\n" +
                    "\tObjectArchetype=SeqAct_ModifyObjectList'Engine.Default__SeqAct_ModifyObjectList'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_2\n" +
                    "\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                    "\tFindVarName=\"CubeMaterialList\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3624\n" +
                    "\tObjPosY=-4720\n" +
                    "\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_2\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_3\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                    "\tFindVarName=\"CubeListCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3488\n" +
                    "\tObjPosY=-4720\n" +
                    "\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_3\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ActivateRemoteEvent Name=SeqAct_ActivateRemoteEvent_5\n" +
                    "\tEventName=\"Update Cubes\"\n" +
                    "\tInputLinks(0)=(DrawY=-4814,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_6')),DrawY=-4814,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-3101,OverrideDelta=99)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3232\n" +
                    "\tObjPosY=-4848\n" +
                    "\tDrawWidth=270\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ActivateRemoteEvent_5\"\n" +
                    "\tObjectArchetype=SeqAct_ActivateRemoteEvent'Engine.Default__SeqAct_ActivateRemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ActivateRemoteEvent Name=SeqAct_ActivateRemoteEvent_6\n" +
                    "\tEventName=\"UpdateCurrentPackageName\"\n" +
                    "\tInputLinks(0)=(DrawY=-4814,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(DrawY=-4814,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-2741,OverrideDelta=99)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2872\n" +
                    "\tObjPosY=-4848\n" +
                    "\tDrawWidth=365\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ActivateRemoteEvent_6\"\n" +
                    "\tObjectArchetype=SeqAct_ActivateRemoteEvent'Engine.Default__SeqAct_ActivateRemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_5\n" +
                    "\tSizeX=1420\n" +
                    "\tSizeY=660\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4808\n" +
                    "\tObjPosY=-5280\n" +
                    "\tObjComment=\"Init\"\n" +
                    "\tDrawWidth=1420\n" +
                    "\tDrawHeight=660\n" +
                    "\tName=\"SequenceFrame_5\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SeqEvent_RemoteEvent Name=SeqEvent_RemoteEvent_1\n" +
                    "\tEventName=\"UpdateCurrentPackageName\"\n" +
                    "\tMaxWidth=304\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ConvertToString'SeqAct_ConvertToString_2')),DrawY=-5086,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-2059,OverrideDelta=69)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2160\n" +
                    "\tObjPosY=-5152\n" +
                    "\tDrawWidth=172\n" +
                    "\tDrawHeight=128\n" +
                    "\tName=\"SeqEvent_RemoteEvent_1\"\n" +
                    "\tObjectArchetype=SeqEvent_RemoteEvent'Engine.Default__SeqEvent_RemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ConvertToString Name=SeqAct_ConvertToString_2\n" +
                    "\tVarSeparator=\".\"\n" +
                    "\tNumberOfInputs=2\n" +
                    "\tInputLinks(0)=(DrawY=-5078,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=GFxAction_Invoke'GFxAction_Invoke_2')),DrawY=-5078,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_6'),DrawX=-1705,OverrideDelta=74)\n" +
                    "\tVariableLinks(1)=(ExpectedType=Class'Engine.SeqVar_Object',LinkedVariables=(SeqVar_Named'SeqVar_Named_18'),LinkDesc=\"Inputs\",PropertyName=\"Targets\",bWriteable=False,DrawX=-1763,bAllowAnyType=True,OverrideDelta=16)\n" +
                    "\tVariableLinks(2)=(ExpectedType=Class'Engine.SeqVar_String',LinkedVariables=(SeqVar_String'SeqVar_String_18'),LinkDesc=\"Output\",bWriteable=True,DrawX=-1645,OverrideDelta=132)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1800\n" +
                    "\tObjPosY=-5112\n" +
                    "\tDrawWidth=194\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ConvertToString_2\"\n" +
                    "\tObjectArchetype=SeqAct_ConvertToString'Engine.Default__SeqAct_ConvertToString'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_6\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                    "\tFindVarName=\"MaterialPackageIndex\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1704\n" +
                    "\tObjPosY=-4992\n" +
                    "\tObjColor=(B=255,G=0,R=255,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_6\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_String Name=SeqVar_String_18\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1384\n" +
                    "\tObjPosY=-4848\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_String_18\"\n" +
                    "\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                "End Object\n" +
                "Begin Object Class=GFxAction_Invoke Name=GFxAction_Invoke_2\n" +
                    "\tMethodName=\"setCurrentPackageName\"\n" +
                    "\tInputLinks(0)=(DrawY=-5070,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(DrawY=-5070,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-1268,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_7'),DrawX=-1210,OverrideDelta=72)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_String'SeqVar_String_18'),LinkDesc=\"Argument[0]\",MinVars=0,DrawX=-1130,OverrideDelta=133)\n" +
                    "\tVariableLinks(3)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_13'),LinkDesc=\"Argument[1]\",PropertyName=\"None_0\",MinVars=0,DrawX=-1031,OverrideDelta=232)\n" +
                    "\tVariableLinks(4)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_12'),LinkDesc=\"Argument[2]\",PropertyName=\"None_1\",MinVars=0,DrawX=-932,OverrideDelta=331)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1304\n" +
                    "\tObjPosY=-5104\n" +
                    "\tDrawWidth=430\n" +
                    "\tDrawHeight=77\n" +
                    "\tName=\"GFxAction_Invoke_2\"\n" +
                    "\tObjectArchetype=GFxAction_Invoke'GFxUI.Default__GFxAction_Invoke'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_7\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Object'\n" +
                    "\tFindVarName=\"LibraryUI\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1240\n" +
                    "\tObjPosY=-4984\n" +
                    "\tObjColor=(B=255,G=0,R=255,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_7\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_13\n" +
                    "\tExpectedType=Class'Engine.SeqVar_String'\n" +
                    "\tFindVarName=\"PreviousMaterialPackage\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1072\n" +
                    "\tObjPosY=-4976\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_13\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_12\n" +
                    "\tExpectedType=Class'Engine.SeqVar_String'\n" +
                    "\tFindVarName=\"NextMaterialPackage\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-928\n" +
                    "\tObjPosY=-4952\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_12\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_IsActionPressed_TA Name=SeqAct_IsActionPressed_TA_9\n" +
                    "\tActionName=\"chatpreset4\"\n" +
                    "\tInputLinks(0)=(DrawY=-4314,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_AddInt'SeqAct_AddInt_5')),DrawY=-4324,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_9')),ActivateDelay=0.050000,DrawY=-4304,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_4'),DrawX=-4642,OverrideDelta=30)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4704\n" +
                    "\tObjPosY=-4360\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_IsActionPressed_TA_9\"\n" +
                    "\tObjectArchetype=SeqAct_IsActionPressed_TA'tagame.Default__SeqAct_IsActionPressed_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_IsActionPressed_TA Name=SeqAct_IsActionPressed_TA_10\n" +
                    "\tActionName=\"chatpreset2\"\n" +
                    "\tInputLinks(0)=(DrawY=-4106,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_AddInt'SeqAct_AddInt_6')),DrawY=-4116,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_10')),ActivateDelay=0.050000,DrawY=-4096,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_4'),DrawX=-4642,OverrideDelta=30)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4704\n" +
                    "\tObjPosY=-4152\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_IsActionPressed_TA_10\"\n" +
                    "\tObjectArchetype=SeqAct_IsActionPressed_TA'tagame.Default__SeqAct_IsActionPressed_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_IsActionPressed_TA Name=SeqAct_IsActionPressed_TA_11\n" +
                    "\tActionName=\"chatpreset3\"\n" +
                    "\tInputLinks(0)=(DrawY=-3778,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_AddInt'SeqAct_AddInt_7')),DrawY=-3788,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_11')),ActivateDelay=0.050000,DrawY=-3768,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_4'),DrawX=-4642,OverrideDelta=30)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4704\n" +
                    "\tObjPosY=-3824\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_IsActionPressed_TA_11\"\n" +
                    "\tObjectArchetype=SeqAct_IsActionPressed_TA'tagame.Default__SeqAct_IsActionPressed_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_IsActionPressed_TA Name=SeqAct_IsActionPressed_TA_3\n" +
                    "\tActionName=\"chatpreset1\"\n" +
                    "\tInputLinks(0)=(DrawY=-3578,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_AddInt'SeqAct_AddInt_4')),DrawY=-3588,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_3')),ActivateDelay=0.050000,DrawY=-3568,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_4'),DrawX=-4642,OverrideDelta=30)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4704\n" +
                    "\tObjPosY=-3624\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_IsActionPressed_TA_3\"\n" +
                    "\tObjectArchetype=SeqAct_IsActionPressed_TA'tagame.Default__SeqAct_IsActionPressed_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Player Name=SeqVar_Player_4\n" +
                    "\tbAllPlayers=False\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4648\n" +
                    "\tObjPosY=-3968\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Player_4\"\n" +
                    "\tObjectArchetype=SeqVar_Player'Engine.Default__SeqVar_Player'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AddInt Name=SeqAct_AddInt_5\n" +
                    "\tInputLinks(0)=(DrawY=-4318,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_CompareInt'SeqCond_CompareInt_0')),DrawY=-4318,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4420,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_10'),DrawX=-4395,OverrideDelta=41)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4346,OverrideDelta=65)\n" +
                    "\tVariableLinks(3)=(DrawX=-4280,OverrideDelta=140)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4440\n" +
                    "\tObjPosY=-4352\n" +
                    "\tDrawWidth=196\n" +
                    "\tDrawHeight=77\n" +
                    "\tName=\"SeqAct_AddInt_5\"\n" +
                    "\tObjectArchetype=SeqAct_AddInt'Engine.Default__SeqAct_AddInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AddInt Name=SeqAct_AddInt_6\n" +
                    "\tInputLinks(0)=(DrawY=-4110,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_CompareInt'SeqCond_CompareInt_0')),DrawY=-4110,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4428,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_11'),DrawX=-4403,OverrideDelta=41)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4354,OverrideDelta=65)\n" +
                    "\tVariableLinks(3)=(DrawX=-4288,OverrideDelta=140)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4448\n" +
                    "\tObjPosY=-4144\n" +
                    "\tDrawWidth=196\n" +
                    "\tDrawHeight=77\n" +
                    "\tName=\"SeqAct_AddInt_6\"\n" +
                    "\tObjectArchetype=SeqAct_AddInt'Engine.Default__SeqAct_AddInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AddInt Name=SeqAct_AddInt_7\n" +
                    "\tInputLinks(0)=(DrawY=-3790,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_CompareInt'SeqCond_CompareInt_1')),DrawY=-3790,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4420,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_12'),DrawX=-4395,OverrideDelta=41)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4346,OverrideDelta=65)\n" +
                    "\tVariableLinks(3)=(DrawX=-4280,OverrideDelta=140)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4440\n" +
                    "\tObjPosY=-3824\n" +
                    "\tDrawWidth=196\n" +
                    "\tDrawHeight=77\n" +
                    "\tName=\"SeqAct_AddInt_7\"\n" +
                    "\tObjectArchetype=SeqAct_AddInt'Engine.Default__SeqAct_AddInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AddInt Name=SeqAct_AddInt_4\n" +
                    "\tInputLinks(0)=(DrawY=-3590,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_CompareInt'SeqCond_CompareInt_1')),DrawY=-3590,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4420,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_13'),DrawX=-4395,OverrideDelta=41)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4346,OverrideDelta=65)\n" +
                    "\tVariableLinks(3)=(DrawX=-4280,OverrideDelta=140)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4440\n" +
                    "\tObjPosY=-3624\n" +
                    "\tDrawWidth=196\n" +
                    "\tDrawHeight=77\n" +
                    "\tName=\"SeqAct_AddInt_4\"\n" +
                    "\tObjectArchetype=SeqAct_AddInt'Engine.Default__SeqAct_AddInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_10\n" +
                    "\tIntValue=-5\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4424\n" +
                    "\tObjPosY=-4248\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_10\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_11\n" +
                    "\tIntValue=-1\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4432\n" +
                    "\tObjPosY=-4040\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_11\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_12\n" +
                    "\tIntValue=1\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4424\n" +
                    "\tObjPosY=-3720\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_12\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_13\n" +
                    "\tIntValue=5\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4408\n" +
                    "\tObjPosY=-3512\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_13\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_14\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                    "\tFindVarName=\"MaterialPackageIndex\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4160\n" +
                    "\tObjPosY=-3968\n" +
                    "\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_14\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqCond_CompareInt Name=SeqCond_CompareInt_0\n" +
                    "\tInputLinks(0)=(DrawY=-4210,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetInt'SeqAct_SetInt_0')),DrawY=-4220,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_7')),DrawY=-4200,OverrideDelta=33)\n" +
                    "\tOutputLinks(2)=(DrawY=-1366,bHidden=True,OverrideDelta=59)\n" +
                    "\tOutputLinks(3)=(DrawY=-1344,bHidden=True,OverrideDelta=81)\n" +
                    "\tOutputLinks(4)=(DrawY=-1322,bHidden=True,OverrideDelta=103)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4055,OverrideDelta=29)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_14'),DrawX=-4030,OverrideDelta=54)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4088\n" +
                    "\tObjPosY=-4256\n" +
                    "\tDrawWidth=91\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqCond_CompareInt_0\"\n" +
                    "\tObjectArchetype=SeqCond_CompareInt'Engine.Default__SeqCond_CompareInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_14\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4056\n" +
                    "\tObjPosY=-4096\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_14\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_SetInt Name=SeqAct_SetInt_0\n" +
                    "\tInputLinks(0)=(DrawY=-4230,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_7')),DrawY=-4230,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_15'),DrawX=-3854,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-3798,OverrideDelta=68)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3888\n" +
                    "\tObjPosY=-4264\n" +
                    "\tDrawWidth=128\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_SetInt_0\"\n" +
                    "\tObjectArchetype=SeqAct_SetInt'Engine.Default__SeqAct_SetInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_15\n" +
                    "\tIntValue=1\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3888\n" +
                    "\tObjPosY=-4176\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_15\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ActivateRemoteEvent Name=SeqAct_ActivateRemoteEvent_7\n" +
                    "\tEventName=\"Update Cubes\"\n" +
                    "\tInputLinks(0)=(DrawY=-3958,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_14'),(LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_16'),(LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_15'),(LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_13')),DrawY=-3958,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-3549,OverrideDelta=99)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3680\n" +
                    "\tObjPosY=-3992\n" +
                    "\tDrawWidth=270\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ActivateRemoteEvent_7\"\n" +
                    "\tObjectArchetype=SeqAct_ActivateRemoteEvent'Engine.Default__SeqAct_ActivateRemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqCond_CompareInt Name=SeqCond_CompareInt_1\n" +
                    "\tInputLinks(0)=(DrawY=-3698,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_7')),DrawY=-3708,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_SetInt'SeqAct_SetInt_3')),DrawY=-3688,OverrideDelta=33)\n" +
                    "\tOutputLinks(2)=(DrawY=-854,bHidden=True,OverrideDelta=59)\n" +
                    "\tOutputLinks(3)=(DrawY=-832,bHidden=True,OverrideDelta=81)\n" +
                    "\tOutputLinks(4)=(DrawY=-810,bHidden=True,OverrideDelta=103)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-4039,OverrideDelta=29)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_15'),DrawX=-4014,OverrideDelta=54)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4072\n" +
                    "\tObjPosY=-3744\n" +
                    "\tDrawWidth=91\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqCond_CompareInt_1\"\n" +
                    "\tObjectArchetype=SeqCond_CompareInt'Engine.Default__SeqCond_CompareInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_15\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                    "\tFindVarName=\"MaterialPackageCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4032\n" +
                    "\tObjPosY=-3520\n" +
                    "\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_15\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_SetInt Name=SeqAct_SetInt_3\n" +
                    "\tInputLinks(0)=(DrawY=-3686,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_7')),DrawY=-3686,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_15'),DrawX=-3854,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_14'),DrawX=-3798,OverrideDelta=68)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3888\n" +
                    "\tObjPosY=-3720\n" +
                    "\tDrawWidth=128\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_SetInt_3\"\n" +
                    "\tObjectArchetype=SeqAct_SetInt'Engine.Default__SeqAct_SetInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_IsActionPressed_TA Name=SeqAct_IsActionPressed_TA_14\n" +
                    "\tActionName=\"chatpreset4\"\n" +
                    "\tInputLinks(0)=(DrawY=-4298,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_14')),ActivateDelay=0.050000,DrawY=-4308,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_9')),DrawY=-4288,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_5'),DrawX=-3226,OverrideDelta=30)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3288\n" +
                    "\tObjPosY=-4344\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_IsActionPressed_TA_14\"\n" +
                    "\tObjectArchetype=SeqAct_IsActionPressed_TA'tagame.Default__SeqAct_IsActionPressed_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Player Name=SeqVar_Player_5\n" +
                    "\tbAllPlayers=False\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3208\n" +
                    "\tObjPosY=-3984\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Player_5\"\n" +
                    "\tObjectArchetype=SeqVar_Player'Engine.Default__SeqVar_Player'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_IsActionPressed_TA Name=SeqAct_IsActionPressed_TA_15\n" +
                    "\tActionName=\"chatpreset2\"\n" +
                    "\tInputLinks(0)=(DrawY=-4122,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_15')),ActivateDelay=0.050000,DrawY=-4132,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_10')),DrawY=-4112,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_5'),DrawX=-3218,OverrideDelta=30)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3280\n" +
                    "\tObjPosY=-4168\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_IsActionPressed_TA_15\"\n" +
                    "\tObjectArchetype=SeqAct_IsActionPressed_TA'tagame.Default__SeqAct_IsActionPressed_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_IsActionPressed_TA Name=SeqAct_IsActionPressed_TA_16\n" +
                    "\tActionName=\"chatpreset3\"\n" +
                    "\tInputLinks(0)=(DrawY=-3786,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_16')),ActivateDelay=0.050000,DrawY=-3796,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_11')),DrawY=-3776,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_5'),DrawX=-3226,OverrideDelta=30)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3288\n" +
                    "\tObjPosY=-3832\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_IsActionPressed_TA_16\"\n" +
                    "\tObjectArchetype=SeqAct_IsActionPressed_TA'tagame.Default__SeqAct_IsActionPressed_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_IsActionPressed_TA Name=SeqAct_IsActionPressed_TA_13\n" +
                    "\tActionName=\"chatpreset1\"\n" +
                    "\tInputLinks(0)=(DrawY=-3618,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_13')),ActivateDelay=0.050000,DrawY=-3628,OverrideDelta=13)\n" +
                    "\tOutputLinks(1)=(Links=((LinkedOp=SeqAct_IsActionPressed_TA'SeqAct_IsActionPressed_TA_3')),DrawY=-3608,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_5'),DrawX=-3218,OverrideDelta=30)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-3280\n" +
                    "\tObjPosY=-3664\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_IsActionPressed_TA_13\"\n" +
                    "\tObjectArchetype=SeqAct_IsActionPressed_TA'tagame.Default__SeqAct_IsActionPressed_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_6\n" +
                    "\tSizeX=1766\n" +
                    "\tSizeY=958\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4808\n" +
                    "\tObjPosY=-4384\n" +
                    "\tObjComment=\"Change package index with input presses\"\n" +
                    "\tDrawWidth=1766\n" +
                    "\tDrawHeight=958\n" +
                    "\tName=\"SequenceFrame_6\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ConvertToString Name=SeqAct_ConvertToString_3\n" +
                    "\tInputLinks(0)=(DrawY=-3166,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_DrawText'SeqAct_DrawText_0')),DrawY=-3166,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_16'),DrawX=-4691,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_String'SeqVar_String_19'),DrawX=-4631,OverrideDelta=74)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4728\n" +
                    "\tObjPosY=-3200\n" +
                    "\tDrawWidth=136\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ConvertToString_3\"\n" +
                    "\tObjectArchetype=SeqAct_ConvertToString'Engine.Default__SeqAct_ConvertToString'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_DrawText Name=SeqAct_DrawText_0\n" +
                    "\tDrawTextInfo=(MessageText=\"Nbr of cube is \",MessageFontScale=(X=2.000000,Y=2.000000),MessageOffset=(X=0.000000,Y=-64.000000))\n" +
                    "\tInputLinks(0)=(DrawY=-3172,OverrideDelta=13)\n" +
                    "\tInputLinks(1)=(DrawY=-3152,OverrideDelta=33)\n" +
                    "\tOutputLinks(0)=(DrawY=-3162,OverrideDelta=23)\n" +
                    "\tVariableLinks(0)=(DrawX=-4458,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_String'SeqVar_String_19'),bHidden=False,DrawX=-4401,OverrideDelta=76)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4496\n" +
                    "\tObjPosY=-3208\n" +
                    "\tDrawWidth=131\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_DrawText_0\"\n" +
                    "\tObjectArchetype=SeqAct_DrawText'Engine.Default__SeqAct_DrawText'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_String Name=SeqVar_String_19\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4640\n" +
                    "\tObjPosY=-3104\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_String_19\"\n" +
                    "\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_16\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                    "\tFindVarName=\"CubeListCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4744\n" +
                    "\tObjPosY=-3096\n" +
                    "\tObjColor=(B=255,G=0,R=255,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_16\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_7\n" +
                    "\tSizeX=464\n" +
                    "\tSizeY=235\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4800\n" +
                    "\tObjPosY=-3240\n" +
                    "\tObjComment=\"DEBUG - Display Cube object list amount (to delete I guess)\"\n" +
                    "\tDrawWidth=464\n" +
                    "\tDrawHeight=235\n" +
                    "\tName=\"SequenceFrame_7\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SeqEvent_RemoteEvent Name=SeqEvent_RemoteEvent_4\n" +
                    "\tEventName=\"TouchedBox\"\n" +
                    "\tMaxWidth=197\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_GetProperty'SeqAct_GetProperty_0')),DrawY=-4166,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_1'),DrawX=-2419,OverrideDelta=69)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2520\n" +
                    "\tObjPosY=-4232\n" +
                    "\tDrawWidth=118\n" +
                    "\tDrawHeight=128\n" +
                    "\tName=\"SeqEvent_RemoteEvent_4\"\n" +
                    "\tObjectArchetype=SeqEvent_RemoteEvent'Engine.Default__SeqEvent_RemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqEvent_RemoteEvent Name=SeqEvent_RemoteEvent_5\n" +
                    "\tEventName=\"UntouchedBox\"\n" +
                    "\tMaxWidth=211\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetString'SeqAct_SetString_0')),DrawY=-3862,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-2419,OverrideDelta=69)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2520\n" +
                    "\tObjPosY=-3928\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=128\n" +
                    "\tName=\"SeqEvent_RemoteEvent_5\"\n" +
                    "\tObjectArchetype=SeqEvent_RemoteEvent'Engine.Default__SeqEvent_RemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Object Name=SeqVar_Object_1\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2440\n" +
                    "\tObjPosY=-4072\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Object_1\"\n" +
                    "\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_GetProperty Name=SeqAct_GetProperty_0\n" +
                    "\tPropertyName=\"StaticMeshComponent\"\n" +
                    "\tInputLinks(0)=(DrawY=-4158,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_GetProperty'SeqAct_GetProperty_2')),DrawY=-4158,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_1'),DrawX=-2178,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_2'),DrawX=-2118,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(DrawX=-2071,OverrideDelta=136)\n" +
                    "\tVariableLinks(3)=(DrawX=-2029,OverrideDelta=171)\n" +
                    "\tVariableLinks(4)=(DrawX=-1977,OverrideDelta=220)\n" +
                    "\tVariableLinks(5)=(DrawX=-1928,OverrideDelta=275)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2216\n" +
                    "\tObjPosY=-4192\n" +
                    "\tDrawWidth=318\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_GetProperty_0\"\n" +
                    "\tObjectArchetype=SeqAct_GetProperty'Engine.Default__SeqAct_GetProperty'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Object Name=SeqVar_Object_2\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2144\n" +
                    "\tObjPosY=-4096\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Object_2\"\n" +
                    "\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_GetProperty Name=SeqAct_GetProperty_2\n" +
                    "\tPropertyName=\"Materials\"\n" +
                    "\tInputLinks(0)=(DrawY=-4158,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=GFxAction_Invoke'GFxAction_Invoke_3')),DrawY=-4158,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_2'),DrawX=-1794,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(DrawX=-1734,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(DrawX=-1687,OverrideDelta=136)\n" +
                    "\tVariableLinks(3)=(DrawX=-1645,OverrideDelta=171)\n" +
                    "\tVariableLinks(4)=(LinkedVariables=(SeqVar_String'SeqVar_String_20'),DrawX=-1593,OverrideDelta=220)\n" +
                    "\tVariableLinks(5)=(DrawX=-1544,OverrideDelta=275)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1832\n" +
                    "\tObjPosY=-4192\n" +
                    "\tDrawWidth=318\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_GetProperty_2\"\n" +
                    "\tObjectArchetype=SeqAct_GetProperty'Engine.Default__SeqAct_GetProperty'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_String Name=SeqVar_String_20\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1608\n" +
                    "\tObjPosY=-3856\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_String_20\"\n" +
                    "\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_SetString Name=SeqAct_SetString_0\n" +
                    "\tInputLinks(0)=(DrawY=-3862,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=GFxAction_Invoke'GFxAction_Invoke_3')),DrawY=-3862,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-2126,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_String'SeqVar_String_20'),DrawX=-2070,OverrideDelta=68)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2160\n" +
                    "\tObjPosY=-3896\n" +
                    "\tDrawWidth=128\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_SetString_0\"\n" +
                    "\tObjectArchetype=SeqAct_SetString'Engine.Default__SeqAct_SetString'\n" +
                "End Object\n" +
                "Begin Object Class=GFxAction_Invoke Name=GFxAction_Invoke_3\n" +
                    "\tMethodName=\"setCurrentAssetName\"\n" +
                    "\tInputLinks(0)=(DrawY=-3918,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(DrawY=-3918,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=-1316,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_17'),DrawX=-1258,OverrideDelta=72)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_String'SeqVar_String_20'),LinkDesc=\"Argument[0]\",MinVars=0,DrawX=-1178,OverrideDelta=133)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1352\n" +
                    "\tObjPosY=-3952\n" +
                    "\tDrawWidth=232\n" +
                    "\tDrawHeight=77\n" +
                    "\tName=\"GFxAction_Invoke_3\"\n" +
                    "\tObjectArchetype=GFxAction_Invoke'GFxUI.Default__GFxAction_Invoke'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_17\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Object'\n" +
                    "\tFindVarName=\"LibraryUI\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1288\n" +
                    "\tObjPosY=-3824\n" +
                    "\tObjColor=(B=255,G=0,R=255,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_17\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_Gate Name=SeqAct_Gate_1\n" +
                    "\tInputLinks(0)=(DrawY=-4147,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-4125,OverrideDelta=36)\n" +
                    "\tInputLinks(2)=(DrawY=-4103,OverrideDelta=58)\n" +
                    "\tInputLinks(3)=(DrawY=-4081,OverrideDelta=80)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_DrawText'SeqAct_DrawText_1')),DrawY=-4114,OverrideDelta=47)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1328\n" +
                    "\tObjPosY=-4184\n" +
                    "\tDrawWidth=82\n" +
                    "\tDrawHeight=117\n" +
                    "\tName=\"SeqAct_Gate_1\"\n" +
                    "\tObjectArchetype=SeqAct_Gate'Engine.Default__SeqAct_Gate'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_Delay Name=SeqAct_Delay_3\n" +
                    "\tDuration=0.010000\n" +
                    "\tInputLinks(0)=(DrawY=-4187,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-4166,OverrideDelta=35)\n" +
                    "\tInputLinks(2)=(DrawY=-4145,OverrideDelta=56)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Gate'SeqAct_Gate_1')),DrawY=-4182,OverrideDelta=19)\n" +
                    "\tOutputLinks(1)=(DrawY=-4150,OverrideDelta=51)\n" +
                    "\tVariableLinks(0)=(DrawX=-860,OverrideDelta=25)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-912\n" +
                    "\tObjPosY=-4224\n" +
                    "\tDrawWidth=106\n" +
                    "\tDrawHeight=109\n" +
                    "\tName=\"SeqAct_Delay_3\"\n" +
                    "\tObjectArchetype=SeqAct_Delay'Engine.Default__SeqAct_Delay'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_DrawText Name=SeqAct_DrawText_1\n" +
                    "\tDisplayTimeSeconds=0.010000\n" +
                    "\tDrawTextInfo=(MessageFontScale=(X=2.000000,Y=2.000000))\n" +
                    "\tInputLinks(0)=(DrawY=-4116,OverrideDelta=13)\n" +
                    "\tInputLinks(1)=(DrawY=-4096,OverrideDelta=33)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Delay'SeqAct_Delay_3')),DrawY=-4106,OverrideDelta=23)\n" +
                    "\tVariableLinks(0)=(DrawX=-1106,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_String'SeqVar_String_20'),bHidden=False,DrawX=-1049,OverrideDelta=76)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1144\n" +
                    "\tObjPosY=-4152\n" +
                    "\tDrawWidth=131\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_DrawText_1\"\n" +
                    "\tObjectArchetype=SeqAct_DrawText'Engine.Default__SeqAct_DrawText'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_9\n" +
                    "\tSizeX=1774\n" +
                    "\tSizeY=532\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-2544\n" +
                    "\tObjPosY=-4256\n" +
                    "\tObjComment=\"Cube Material name display\"\n" +
                    "\tDrawWidth=1774\n" +
                    "\tDrawHeight=532\n" +
                    "\tName=\"SequenceFrame_9\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_10\n" +
                    "\tSizeX=1373\n" +
                    "\tSizeY=323\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4776\n" +
                    "\tObjPosY=-5872\n" +
                    "\tObjComment=\"Variables / sequences\"\n" +
                    "\tDrawWidth=1373\n" +
                    "\tDrawHeight=323\n" +
                    "\tName=\"SequenceFrame_10\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_18\n" +
                    "\tExpectedType=Class'Engine.SeqVar_String'\n" +
                    "\tFindVarName=\"CurrentMaterialPackage\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-1840\n" +
                    "\tObjPosY=-4968\n" +
                    "\tObjColor=(B=255,G=0,R=255,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_18\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n";

            // Packages object list
            Packages.ForEach(p => Kismet += p.GetSerialized());

            Kismet += SerializeUpdateMaterialCubesKismet();

            Console.WriteLine("Level -> Kismet serialization done.");
        }

        private string SerializeUpdateMaterialCubesKismet()
        {
            var updateMaterialCubesKismet =
                "Begin Object Class=Sequence Name=UpdateMaterialCubes\n" +
                    "\tBegin Object Class=SeqEvent_RemoteEvent Name=SeqEvent_RemoteEvent_1\n" +
                        "\t\tEventName=\"Update Cubes\"\n" +
                        "\t\tMaxWidth=209\n" +
                        "\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_146')),DrawY=-6926,OverrideDelta=11)\n" +
                        "\t\tVariableLinks(0)=(DrawX=-9144,OverrideDelta=72)\n" +
                        "\t\tObjInstanceVersion=2\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-9248\n" +
                        "\t\tObjPosY=-6992\n" +
                        "\t\tDrawWidth=124\n" +
                        "\t\tDrawHeight=128\n" +
                        "\t\tName=\"SeqEvent_RemoteEvent_1\"\n" +
                        "\t\tObjectArchetype=SeqEvent_RemoteEvent'Engine.Default__SeqEvent_RemoteEvent'\n" +
                    "\tEnd Object\n" +
                    "\tBegin Object Class=SeqAct_Delay Name=SeqAct_Delay_3\n" +
                        "\t\tDuration=0.100000\n" +
                        "\t\tInputLinks(0)=(DrawY=-6923,OverrideDelta=14)\n" +
                        "\t\tInputLinks(1)=(DrawY=-6902,OverrideDelta=35)\n" +
                        "\t\tInputLinks(2)=(DrawY=-6881,OverrideDelta=56)\n" +
                        "\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Switch'SeqAct_Switch_1'),(LinkedOp=SeqAct_Switch'SeqAct_Switch_0')),DrawY=-6918,OverrideDelta=19)\n" +
                        "\t\tOutputLinks(1)=(DrawY=-6886,OverrideDelta=51)\n" +
                        "\t\tVariableLinks(0)=(DrawX=-8516,OverrideDelta=25)\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-8568\n" +
                        "\t\tObjPosY=-6960\n" +
                        "\t\tObjComment=\"Safety: make sure all cube are already hidden before going on\"\n" +
                        "\t\tDrawWidth=106\n" +
                        "\t\tDrawHeight=109\n" +
                        "\t\tName=\"SeqAct_Delay_3\"\n" +
                        "\t\tObjectArchetype=SeqAct_Delay'Engine.Default__SeqAct_Delay'\n" +
                    "\tEnd Object\n" +
                    "\tBegin Object Class=SeqAct_ActivateRemoteEvent Name=SeqAct_ActivateRemoteEvent_146\n" +
                        "\t\tEventName=\"HideAllCubes\"\n" +
                        "\t\tInputLinks(0)=(DrawY=-6926,OverrideDelta=11)\n" +
                        "\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Delay'SeqAct_Delay_3')),DrawY=-6926,OverrideDelta=11)\n" +
                        "\t\tVariableLinks(0)=(DrawX=-8790,OverrideDelta=98)\n" +
                        "\t\tObjInstanceVersion=3\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-8920\n" +
                        "\t\tObjPosY=-6960\n" +
                        "\t\tDrawWidth=261\n" +
                        "\t\tDrawHeight=61\n" +
                        "\t\tName=\"SeqAct_ActivateRemoteEvent_146\"\n" +
                        "\t\tObjectArchetype=SeqAct_ActivateRemoteEvent'Engine.Default__SeqAct_ActivateRemoteEvent'\n" +
                    "\tEnd Object\n" +
                    // Assign materials switch
                    "\tBegin Object Class=SeqAct_Switch Name=SeqAct_Switch_1\n" +
                        $"\t\tLinkCount={Packages.Count}\n" +
                        "\t\tIncrementAmount=0\n" +
                        "\t\tInputLinks(0)=(DrawY=-6284,OverrideDelta=599)\n";

            var assignMatSwitchDrawY = -6853;
            var assignMatSwitchOverrideDelta = 36;

            for (int i = 1; i <= Packages.Count; i++)
            {
                updateMaterialCubesKismet +=
                        $"\t\tOutputLinks({i - 1})=(Links=((LinkedOp=Sequence'AssignMaterials";
                updateMaterialCubesKismet += i == 1 ? "" : $"_{i}";
                updateMaterialCubesKismet +=
                        $"')),LinkDesc=\"Link {i}\",DrawY={assignMatSwitchDrawY},OverrideDelta={assignMatSwitchOverrideDelta})\n";

                assignMatSwitchDrawY += 22;
                assignMatSwitchOverrideDelta += 22;
            }

            updateMaterialCubesKismet +=
                        "\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_48'),DrawX=-8235,OverrideDelta=18)\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-8271\n" +
                        "\t\tObjPosY=-6906\n" +
                        "\t\tDrawWidth=73\n" +
                        "\t\tDrawHeight=1237\n" +
                        "\t\tName=\"SeqAct_Switch_1\"\n" +
                        "\t\tObjectArchetype=SeqAct_Switch'Engine.Default__SeqAct_Switch'\n" +
                    "\tEnd Object\n" +
                    "\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_48\n" +
                        "\t\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                        "\t\tFindVarName=\"MaterialPackageIndex\"\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-8272\n" +
                        $"\t\tObjPosY={assignMatSwitchDrawY + 25}\n" +
                        "\t\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                        "\t\tDrawWidth=32\n" +
                        "\t\tDrawHeight=32\n" +
                        "\t\tName=\"SeqVar_Named_48\"\n" +
                        "\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                    "\tEnd Object\n";

            var sequenceNameVarPosX = -7080;

            for (int i = 1; i <= Packages.Count; i++)
            {
                updateMaterialCubesKismet +=
                    $"\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_{i + 565}\n" +
                        "\t\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                        $"\t\tFindVarName=\"mats_{Packages[i - 1].Name}\"\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        $"\t\tObjPosX={sequenceNameVarPosX}\n" +
                        "\t\tObjPosY=-7544\n" +
                        "\t\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                        "\t\tDrawWidth=32\n" +
                        "\t\tDrawHeight=32\n" +
                        $"\t\tName=\"SeqVar_Named_{i + 565}\"\n" +
                        "\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                    "\tEnd Object\n";

                sequenceNameVarPosX += 264;
            }

            // AssignMaterials sequences
            var assignMatsSequencePosX = -7112;

            for (int i = 1; i <= Packages.Count; i++)
            {
                var sequenceName = i == 1 ? "AssignMaterials" : $"AssignMaterials_{i}";

                updateMaterialCubesKismet +=
                    $"\tBegin Object Class=Sequence Name={sequenceName}\n" +
                        $"\t\tBegin Object Class=SeqVar_Object Name=SeqVar_Object_{i + 1004}\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5312\n" +
                            "\t\t\tObjPosY=-6016\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Object_{i + 1004}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Object Name=SeqVar_Object_{i + 1503}\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-4888\n" +
                            "\t\t\tObjPosY=-6608\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Object_{i + 1503}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Object Name=SeqVar_Object_{i + 2002}\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5016\n" +
                            "\t\t\tObjPosY=-6424\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Object_{i + 2002}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_{i + 2521}\n" +
                            "\t\t\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                            "\t\t\tFindVarName=\"CubeMaterialList\"\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5464\n" +
                            "\t\t\tObjPosY=-5960\n" +
                            "\t\t\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Named_{i + 2521}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_{i + 3020}\n" +
                            "\t\t\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                            "\t\t\tFindVarName=\"CubeListCount\"\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5648\n" +
                            "\t\t\tObjPosY=-5936\n" +
                            "\t\t\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Named_{i + 3020}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_{i + 3519}\n" +
                            "\t\t\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                            "\t\t\tFindVarName=\"CubeMaterialList\"\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5120\n" +
                            "\t\t\tObjPosY=-6552\n" +
                            "\t\t\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Named_{i + 3519}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_{i + 4018}\n" +
                            "\t\t\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                            "\t\t\tFindVarName=\"CubeListCount\"\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5680\n" +
                            "\t\t\tObjPosY=-6576\n" +
                            "\t\t\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Named_{i + 4018}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Int Name=SeqVar_Int_{i + 4517}\n" +
                            "\t\t\tIntValue=-1\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5744\n" +
                            "\t\t\tObjPosY=-6440\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Int_{i + 4517}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Int Name=SeqVar_Int_{i + 5016}\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-6144\n" +
                            "\t\t\tObjPosY=-6608\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Int_{i + 5016}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_Int Name=SeqVar_Int_{i + 5515}\n" +
                            "\t\t\tIntValue=-1\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-6574\n" +
                            "\t\t\tObjPosY=-6687\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_Int_{i + 5515}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqVar_External Name=SeqVar_External_{i + 6050}\n" +
                            "\t\t\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-6272\n" +
                            "\t\t\tObjPosY=-6536\n" +
                            "\t\t\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                            "\t\t\tDrawWidth=32\n" +
                            "\t\t\tDrawHeight=32\n" +
                            $"\t\t\tName=\"SeqVar_External_{i + 6050}\"\n" +
                            "\t\t\tObjectArchetype=SeqVar_External'Engine.Default__SeqVar_External'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqEvent_SequenceActivated Name=SeqEvent_SequenceActivated_{i + 6501}\n" +
                            "\t\t\tMaxWidth=172\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetInt'SeqAct_SetInt_{i + 1503}')),DrawY=-6742,OverrideDelta=11)\n" +
                            "\t\t\tVariableLinks(0)=(DrawX=-6746,OverrideDelta=54)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-6832\n" +
                            "\t\t\tObjPosY=-6808\n" +
                            "\t\t\tDrawWidth=106\n" +
                            "\t\t\tDrawHeight=128\n" +
                            $"\t\t\tName=\"SeqEvent_SequenceActivated_{i + 6501}\"\n" +
                            "\t\t\tObjectArchetype=SeqEvent_SequenceActivated'Engine.Default__SeqEvent_SequenceActivated'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqCond_Increment Name=SeqCond_Increment_{i + 6501}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6722,OverrideDelta=23)\n" +
                            "\t\t\tOutputLinks(0)=(DrawY=-6762,bHidden=True,OverrideDelta=15)\n" +
                            "\t\t\tOutputLinks(1)=(DrawY=-6740,bHidden=True,OverrideDelta=37)\n" +
                            "\t\t\tOutputLinks(2)=(DrawY=-6718,bHidden=True,OverrideDelta=59)\n" +
                            $"\t\t\tOutputLinks(3)=(Links=((LinkedOp=SeqCond_CompareInt'SeqCond_CompareInt_{i + 7001}')),DrawY=-6732,OverrideDelta=13)\n" +
                            $"\t\t\tOutputLinks(4)=(Links=((LinkedOp=SeqCond_CompareInt'SeqCond_CompareInt_{i + 2002}')),DrawY=-6712,OverrideDelta=33)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 4517}'),DrawX=-5922,OverrideDelta=26)\n" +
                            $"\t\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 5016}'),DrawX=-5897,OverrideDelta=51)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5952\n" +
                            "\t\t\tObjPosY=-6768\n" +
                            "\t\t\tDrawWidth=86\n" +
                            "\t\t\tDrawHeight=85\n" +
                            $"\t\t\tName=\"SeqCond_Increment_{i + 6501}\"\n" +
                            "\t\t\tObjectArchetype=SeqCond_Increment'Engine.Default__SeqCond_Increment'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqCond_CompareInt Name=SeqCond_CompareInt_{i + 2002}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6126,OverrideDelta=59)\n" +
                            "\t\t\tOutputLinks(0)=(DrawY=-6170,OverrideDelta=15)\n" +
                            "\t\t\tOutputLinks(1)=(DrawY=-6148,OverrideDelta=37)\n" +
                            "\t\t\tOutputLinks(2)=(DrawY=-6126,OverrideDelta=59)\n" +
                            $"\t\t\tOutputLinks(3)=(Links=((LinkedOp=SeqAct_AccessObjectList'SeqAct_AccessObjectList_{i + 7001}',InputLinkIdx=3)),DrawY=-6104,OverrideDelta=81)\n" +
                            "\t\t\tOutputLinks(4)=(DrawY=-6082,OverrideDelta=103)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 4517}'),DrawX=-5671,OverrideDelta=29)\n" +
                            $"\t\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_{i + 3020}'),DrawX=-5646,OverrideDelta=54)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5704\n" +
                            "\t\t\tObjPosY=-6208\n" +
                            "\t\t\tDrawWidth=91\n" +
                            "\t\t\tDrawHeight=157\n" +
                            $"\t\t\tName=\"SeqCond_CompareInt_{i + 2002}\"\n" +
                            "\t\t\tObjectArchetype=SeqCond_CompareInt'Engine.Default__SeqCond_CompareInt'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqCond_CompareInt Name=SeqCond_CompareInt_{i + 7001}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6702,OverrideDelta=11)\n" +
                            "\t\t\tOutputLinks(0)=(DrawY=-6754,bHidden=True,OverrideDelta=15)\n" +
                            "\t\t\tOutputLinks(1)=(DrawY=-6732,bHidden=True,OverrideDelta=37)\n" +
                            "\t\t\tOutputLinks(2)=(DrawY=-6710,bHidden=True,OverrideDelta=59)\n" +
                            $"\t\t\tOutputLinks(3)=(Links=((LinkedOp=SeqAct_AccessObjectList'SeqAct_AccessObjectList_{i + 6501}',InputLinkIdx=3)),DrawY=-6702,OverrideDelta=11)\n" +
                            "\t\t\tOutputLinks(4)=(DrawY=-6666,bHidden=True,OverrideDelta=103)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 4517}'),DrawX=-5711,OverrideDelta=29)\n" +
                            $"\t\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_{i + 4018}'),DrawX=-5686,OverrideDelta=54)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5744\n" +
                            "\t\t\tObjPosY=-6736\n" +
                            "\t\t\tDrawWidth=91\n" +
                            "\t\t\tDrawHeight=61\n" +
                            $"\t\t\tName=\"SeqCond_CompareInt_{i + 7001}\"\n" +
                            "\t\t\tObjectArchetype=SeqCond_CompareInt'Engine.Default__SeqCond_CompareInt'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqAct_ToggleHidden Name=SeqAct_ToggleHidden_{i + 6501}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6707,OverrideDelta=14)\n" +
                            "\t\t\tInputLinks(1)=(DrawY=-6686,OverrideDelta=35)\n" +
                            "\t\t\tInputLinks(2)=(DrawY=-6665,OverrideDelta=56)\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_Increment'SeqCond_Increment_{i + 6501}')),DrawY=-6686,OverrideDelta=35)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_{i + 1503}'),DrawX=-4506,OverrideDelta=16)\n" +
                            "\t\t\tVariableLinks(1)=(DrawX=-4455,OverrideDelta=76)\n" +
                            "\t\t\tEventLinks(0)=(DrawX=-4406,OverrideDelta=119)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-4544\n" +
                            "\t\t\tObjPosY=-6744\n" +
                            "\t\t\tDrawWidth=173\n" +
                            "\t\t\tDrawHeight=109\n" +
                            $"\t\t\tName=\"SeqAct_ToggleHidden_{i + 6501}\"\n" +
                            "\t\t\tObjectArchetype=SeqAct_ToggleHidden'Engine.Default__SeqAct_ToggleHidden'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqAct_SetMaterial Name=SeqAct_SetMaterial_{i + 7500}\n" +
                            "\t\t\tNewMaterial=MaterialInstanceConstant'Invisible'\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6110,OverrideDelta=11)\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_Increment'SeqCond_Increment_{i + 6501}')),DrawY=-6110,OverrideDelta=11)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_{i + 1004}'),DrawX=-5163,OverrideDelta=23)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5208\n" +
                            "\t\t\tObjPosY=-6144\n" +
                            "\t\t\tDrawWidth=90\n" +
                            "\t\t\tDrawHeight=61\n" +
                            $"\t\t\tName=\"SeqAct_SetMaterial_{i + 7500}\"\n" +
                            "\t\t\tObjectArchetype=SeqAct_SetMaterial'Engine.Default__SeqAct_SetMaterial'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqAct_SetMaterial Name=SeqAct_SetMaterial_{i + 6501}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6702,OverrideDelta=11)\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ToggleHidden'SeqAct_ToggleHidden_{i + 6501}',InputLinkIdx=1)),DrawY=-6702,OverrideDelta=11)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_{i + 1503}'),DrawX=-4770,OverrideDelta=16)\n" +
                            $"\t\t\tVariableLinks(1)=(ExpectedType=Class'Engine.SeqVar_Object',LinkedVariables=(SeqVar_Object'SeqVar_Object_{i + 2002}'),LinkDesc=\"NewMaterial\",PropertyName=\"NewMaterial\",MinVars=0,DrawX=-4692,OverrideDelta=76)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-4808\n" +
                            "\t\t\tObjPosY=-6736\n" +
                            "\t\t\tDrawWidth=172\n" +
                            "\t\t\tDrawHeight=61\n" +
                            $"\t\t\tName=\"SeqAct_SetMaterial_{i + 6501}\"\n" +
                            "\t\t\tObjectArchetype=SeqAct_SetMaterial'Engine.Default__SeqAct_SetMaterial'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqAct_SetInt Name=SeqAct_SetInt_{i + 1503}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6734,OverrideDelta=11)\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ModifyObjectList'SeqAct_ModifyObjectList_{i + 7500}',InputLinkIdx=1)),DrawY=-6734,OverrideDelta=11)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 5515}'),DrawX=-6542,OverrideDelta=16)\n" +
                            $"\t\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 4517}'),DrawX=-6486,OverrideDelta=68)\n" +
                            "\t\t\tObjInstanceVersion=2\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-6576\n" +
                            "\t\t\tObjPosY=-6768\n" +
                            "\t\t\tDrawWidth=128\n" +
                            "\t\t\tDrawHeight=61\n" +
                            $"\t\t\tName=\"SeqAct_SetInt_{i + 1503}\"\n" +
                            "\t\t\tObjectArchetype=SeqAct_SetInt'Engine.Default__SeqAct_SetInt'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqAct_ModifyObjectList Name=SeqAct_ModifyObjectList_{i + 7500}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6755,OverrideDelta=14)\n" +
                            "\t\t\tInputLinks(1)=(DrawY=-6734,OverrideDelta=35)\n" +
                            "\t\t\tInputLinks(2)=(DrawY=-6713,OverrideDelta=56)\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_Increment'SeqCond_Increment_{i + 6501}')),DrawY=-6734,OverrideDelta=35)\n" +
                            "\t\t\tVariableLinks(0)=(DrawX=-6306,OverrideDelta=16)\n" +
                            $"\t\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_External'SeqVar_External_{i + 6050}'),DrawX=-6246,OverrideDelta=76)\n" +
                            $"\t\t\tVariableLinks(2)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 5016}'),DrawX=-6165,OverrideDelta=137)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-6344\n" +
                            "\t\t\tObjPosY=-6792\n" +
                            "\t\t\tDrawWidth=237\n" +
                            "\t\t\tDrawHeight=125\n" +
                            $"\t\t\tName=\"SeqAct_ModifyObjectList_{i + 7500}\"\n" +
                            "\t\t\tObjectArchetype=SeqAct_ModifyObjectList'Engine.Default__SeqAct_ModifyObjectList'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqAct_AccessObjectList Name=SeqAct_AccessObjectList_{i + 7001}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6163,OverrideDelta=14)\n" +
                            "\t\t\tInputLinks(1)=(DrawY=-6141,OverrideDelta=36)\n" +
                            "\t\t\tInputLinks(2)=(DrawY=-6119,OverrideDelta=58)\n" +
                            "\t\t\tInputLinks(3)=(DrawY=-6097,OverrideDelta=80)\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetMaterial'SeqAct_SetMaterial_{i + 7500}')),DrawY=-6130,OverrideDelta=47)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_{i + 2521}'),DrawX=-5450,OverrideDelta=16)\n" +
                            $"\t\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 4517}'),DrawX=-5394,OverrideDelta=76)\n" +
                            $"\t\t\tVariableLinks(2)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_{i + 1004}'),DrawX=-5336,OverrideDelta=128)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5488\n" +
                            "\t\t\tObjPosY=-6200\n" +
                            "\t\t\tDrawWidth=193\n" +
                            "\t\t\tDrawHeight=149\n" +
                            $"\t\t\tName=\"SeqAct_AccessObjectList_{i + 7001}\"\n" +
                            "\t\t\tObjectArchetype=SeqAct_AccessObjectList'Engine.Default__SeqAct_AccessObjectList'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqAct_AccessObjectList Name=SeqAct_AccessObjectList_{i + 7500}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6763,OverrideDelta=14)\n" +
                            "\t\t\tInputLinks(1)=(DrawY=-6741,OverrideDelta=36)\n" +
                            "\t\t\tInputLinks(2)=(DrawY=-6719,OverrideDelta=58)\n" +
                            "\t\t\tInputLinks(3)=(DrawY=-6697,OverrideDelta=80)\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetMaterial'SeqAct_SetMaterial_{i + 6501}')),DrawY=-6730,OverrideDelta=47)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_{i + 3519}'),DrawX=-5098,OverrideDelta=16)\n" +
                            $"\t\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 4517}'),DrawX=-5042,OverrideDelta=76)\n" +
                            $"\t\t\tVariableLinks(2)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_{i + 1503}'),DrawX=-4984,OverrideDelta=128)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5136\n" +
                            "\t\t\tObjPosY=-6800\n" +
                            "\t\t\tDrawWidth=193\n" +
                            "\t\t\tDrawHeight=149\n" +
                            $"\t\t\tName=\"SeqAct_AccessObjectList_{i + 7500}\"\n" +
                            "\t\t\tObjectArchetype=SeqAct_AccessObjectList'Engine.Default__SeqAct_AccessObjectList'\n" +
                        "\t\tEnd Object\n" +
                        $"\t\tBegin Object Class=SeqAct_AccessObjectList Name=SeqAct_AccessObjectList_{i + 6501}\n" +
                            "\t\t\tInputLinks(0)=(DrawY=-6755,OverrideDelta=14)\n" +
                            "\t\t\tInputLinks(1)=(DrawY=-6733,OverrideDelta=36)\n" +
                            "\t\t\tInputLinks(2)=(DrawY=-6711,OverrideDelta=58)\n" +
                            "\t\t\tInputLinks(3)=(DrawY=-6689,OverrideDelta=80)\n" +
                            $"\t\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_AccessObjectList'SeqAct_AccessObjectList_{i + 7500}',InputLinkIdx=3)),DrawY=-6722,OverrideDelta=47)\n" +
                            $"\t\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_External'SeqVar_External_{i + 6050}'),DrawX=-5498,OverrideDelta=16)\n" +
                            $"\t\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_{i + 4517}'),DrawX=-5442,OverrideDelta=76)\n" +
                            $"\t\t\tVariableLinks(2)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_{i + 2002}'),DrawX=-5384,OverrideDelta=128)\n" +
                            "\t\t\tObjInstanceVersion=1\n" +
                            $"\t\t\tParentSequence=Sequence'{sequenceName}'\n" +
                            "\t\t\tObjPosX=-5536\n" +
                            "\t\t\tObjPosY=-6792\n" +
                            "\t\t\tDrawWidth=193\n" +
                            "\t\t\tDrawHeight=149\n" +
                            $"\t\t\tName=\"SeqAct_AccessObjectList_{i + 6501}\"\n" +
                            "\t\t\tObjectArchetype=SeqAct_AccessObjectList'Engine.Default__SeqAct_AccessObjectList'\n" +
                        "\t\tEnd Object\n" +
                        "\t\tDefaultViewX=5007\n" +
                        "\t\tDefaultViewY=4912\n" +
                        "\t\tDefaultViewZoom=0.700000\n" +
                        $"\t\tInputLinks(0)=(LinkDesc=\"In\",LinkedOp=SeqEvent_SequenceActivated'SeqEvent_SequenceActivated_{i + 6501}',DrawY=-7646,OverrideDelta=11)\n" +
                        $"\t\tVariableLinks(0)=(ExpectedType=Class'Engine.SeqVar_ObjectList',LinkedVariables=(SeqVar_Named'SeqVar_Named_{i + 565}'),LinkDesc=\"Default Var\",LinkVar=\"SeqVar_External_{i + 6050}\",MinVars=0,DrawX=-3057,OverrideDelta=32)\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        $"\t\tObjPosX={assignMatsSequencePosX}\n" +
                        "\t\tObjPosY=-7680\n" +
                        $"\t\tObjName=\"{sequenceName}\"\n" +
                        "\t\tDrawWidth=111\n" +
                        "\t\tDrawHeight=77\n" +
                        $"\t\tName=\"{sequenceName}\"\n" +
                        "\t\tObjectArchetype=Sequence'Engine.Default__Sequence'\n" +
                    "\tEnd Object\n";

                assignMatsSequencePosX += 264;
            }

            // Update package names switch
            updateMaterialCubesKismet +=
                    "\tBegin Object Class=SeqAct_Switch Name=SeqAct_Switch_0\n" +
                        $"\t\tLinkCount={Packages.Count}\n" +
                        "\t\tIncrementAmount=0\n" +
                        "\t\tInputLinks(0)=(DrawY=-7418,OverrideDelta=599)\n";

            var updateNameSwitchDrawY = -3981;
            var updateNameSwitchOverrideDelta = 36;

            for (int i = 1; i <= Packages.Count; i++)
            {
                updateMaterialCubesKismet +=
                        $"\t\tOutputLinks({i - 1})=(Links=((LinkedOp=SeqAct_SetString'SeqAct_SetString_{i + 45015}')),LinkDesc=\"Link {i}\",DrawY={updateNameSwitchDrawY},OverrideDelta={updateNameSwitchOverrideDelta})\n";

                updateNameSwitchDrawY += 22;
                updateNameSwitchOverrideDelta += 22;
            }

            updateMaterialCubesKismet +=
                        "\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_38'),DrawX=-8252,OverrideDelta=18)\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-8288\n" +
                        "\t\tObjPosY=-4040\n" +
                        "\t\tDrawWidth=73\n" +
                        "\t\tDrawHeight=1237\n" +
                        "\t\tName=\"SeqAct_Switch_0\"\n" +
                        "\t\tObjectArchetype=SeqAct_Switch'Engine.Default__SeqAct_Switch'\n" +
                    "\tEnd Object\n" +
                    "\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_38\n" +
                        "\t\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                        "\t\tFindVarName=\"MaterialPackageIndex\"\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-8288\n" +
                        $"\t\tObjPosY={updateNameSwitchDrawY + 25}\n" +
                        "\t\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                        "\t\tDrawWidth=32\n" +
                        "\t\tDrawHeight=32\n" +
                        "\t\tName=\"SeqVar_Named_38\"\n" +
                        "\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                    "\tEnd Object\n";





            // Update package names logic
            var updatePackageNamePosY = -5000;

            for (int i = 1; i <= Packages.Count; i++)
            {
                updateMaterialCubesKismet +=
                    $"\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_{i + 15057}\n" +
                        "\t\tExpectedType=Class'Engine.SeqVar_String'\n" +
                        "\t\tFindVarName=\"NextMaterialPackage\"\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-7344\n" +
                        $"\t\tObjPosY={updatePackageNamePosY + 100}\n" +
                        "\t\tObjColor=(B=0,G=255,R=0,A=255)\n" +
                        "\t\tDrawWidth=32\n" +
                        "\t\tDrawHeight=32\n" +
                        $"\t\tName=\"SeqVar_Named_{i + 15057}\"\n" +
                        "\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                    "\tEnd Object\n" +
                    $"\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_{i + 20056}\n" +
                        "\t\tExpectedType=Class'Engine.SeqVar_String'\n" +
                        "\t\tFindVarName=\"PreviousMaterialPackage\"\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-7905\n" +
                        $"\t\tObjPosY={updatePackageNamePosY + 100}\n" +
                        "\t\tObjColor=(B=0,G=255,R=0,A=255)\n" +
                        "\t\tDrawWidth=32\n" +
                        "\t\tDrawHeight=32\n" +
                        $"\t\tName=\"SeqVar_Named_{i + 20056}\"\n" +
                        "\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                    "\tEnd Object\n" +
                    $"\tBegin Object Class=SeqVar_Named Name=SeqVar_Named_{i + 25055}\n" +
                        "\t\tExpectedType=Class'Engine.SeqVar_String'\n" +
                        "\t\tFindVarName=\"CurrentMaterialPackage\"\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-7664\n" +
                        $"\t\tObjPosY={updatePackageNamePosY + 100}\n" +
                        "\t\tObjColor=(B=0,G=255,R=0,A=255)\n" +
                        "\t\tDrawWidth=32\n" +
                        "\t\tDrawHeight=32\n" +
                        $"\t\tName=\"SeqVar_Named_{i + 25055}\"\n" +
                        "\t\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                    "\tEnd Object\n" +
                    // Set string previous
                    $"\tBegin Object Class=SeqAct_SetString Name=SeqAct_SetString_{i + 45015}\n" +
                        $"\t\tInputLinks(0)=(DrawY={updatePackageNamePosY},OverrideDelta=11)\n" +
                        $"\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetString'SeqAct_SetString_{i + 50014}')),DrawY={updatePackageNamePosY},OverrideDelta=11)\n";

                if (i == 1)
                {
                    updateMaterialCubesKismet +=
                        "\t\tVariableLinks(0)=(DrawX=-7934,OverrideDelta=16)\n";
                }
                else
                {
                    updateMaterialCubesKismet +=
                        $"\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_String'SeqVar_String_{i - 1 + 55007}'),DrawX=-7878,OverrideDelta=16)\n";
                }

                updateMaterialCubesKismet +=
                        $"\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_{i + 20056}'),DrawX=-7878,OverrideDelta=68)\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-7968\n" +
                        $"\t\tObjPosY={updatePackageNamePosY}\n" +
                        "\t\tDrawWidth=128\n" +
                        "\t\tDrawHeight=61\n" +
                        $"\t\tName=\"SeqAct_SetString_{i + 45015}\"\n" +
                        "\t\tObjectArchetype=SeqAct_SetString'Engine.Default__SeqAct_SetString'\n" +
                    "\tEnd Object\n" +
                    // Set string current
                    $"\tBegin Object Class=SeqAct_SetString Name=SeqAct_SetString_{i + 50014}\n" +
                        $"\t\tInputLinks(0)=(DrawY={updatePackageNamePosY},OverrideDelta=11)\n" +
                        $"\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetString'SeqAct_SetString_{i + 30016}')),DrawY={updatePackageNamePosY},OverrideDelta=11)\n" +
                        $"\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_String'SeqVar_String_{i + 55007}'),DrawX=-7686,OverrideDelta=16)\n" +
                        $"\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_{i + 25055}'),DrawX=-7630,OverrideDelta=68)\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-7720\n" +
                        $"\t\tObjPosY={updatePackageNamePosY}\n" +
                        "\t\tDrawWidth=128\n" +
                        "\t\tDrawHeight=61\n" +
                        $"\t\tName=\"SeqAct_SetString_{i + 50014}\"\n" +
                        "\t\tObjectArchetype=SeqAct_SetString'Engine.Default__SeqAct_SetString'\n" +
                    "\tEnd Object\n" +
                    // Set string next
                    $"\tBegin Object Class=SeqAct_SetString Name=SeqAct_SetString_{i + 30016}\n" +
                        $"\t\tInputLinks(0)=(DrawY={updatePackageNamePosY},OverrideDelta=11)\n" +
                        $"\t\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_{i + 35003}')),DrawY={updatePackageNamePosY},OverrideDelta=11)\n";

                if (i < Packages.Count)
                {
                    updateMaterialCubesKismet +=
                        $"\t\tVariableLinks(0)=(LinkedVariables=(SeqVar_String'SeqVar_String_{i + 1 + 55007}'),DrawX=-7406,OverrideDelta=68)\n";
                }
                else
                {
                    updateMaterialCubesKismet +=
                        "\t\tVariableLinks(0)=(DrawX=-7406,OverrideDelta=68)\n";
                }

                updateMaterialCubesKismet +=
                        $"\t\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_{i + 15057}'),DrawX=-7350,OverrideDelta=68)\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-7440\n" +
                        $"\t\tObjPosY={updatePackageNamePosY}\n" +
                        "\t\tDrawWidth=128\n" +
                        "\t\tDrawHeight=61\n" +
                        $"\t\tName=\"SeqAct_SetString_{i + 30016}\"\n" +
                        "\t\tObjectArchetype=SeqAct_SetString'Engine.Default__SeqAct_SetString'\n" +
                    "\tEnd Object\n" +
                    $"\tBegin Object Class=SeqAct_ActivateRemoteEvent Name=SeqAct_ActivateRemoteEvent_{i + 35003}\n" +
                        "\t\tEventName=\"UpdateCurrentPackageName\"\n" +
                        $"\t\tInputLinks(0)=(DrawY={updatePackageNamePosY},OverrideDelta=11)\n" +
                        $"\t\tOutputLinks(0)=(DrawY={updatePackageNamePosY},OverrideDelta=11)\n" +
                        "\t\tVariableLinks(0)=(DrawX=-6890,OverrideDelta=150)\n" +
                        "\t\tObjInstanceVersion=3\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-7072\n" +
                        $"\t\tObjPosY={updatePackageNamePosY}\n" +
                        "\t\tDrawWidth=365\n" +
                        "\t\tDrawHeight=61\n" +
                        $"\t\tName=\"SeqAct_ActivateRemoteEvent_{i + 35003}\"\n" +
                        "\t\tObjectArchetype=SeqAct_ActivateRemoteEvent'Engine.Default__SeqAct_ActivateRemoteEvent'\n" +
                    "\tEnd Object\n" +
                    $"\tBegin Object Class=SeqVar_String Name=SeqVar_String_{i + 55007}\n" +
                        $"\t\tStrValue=\"{Packages[i - 1].Name}\"\n" +
                        "\t\tObjInstanceVersion=1\n" +
                        "\t\tParentSequence=Sequence'UpdateMaterialCubes'\n" +
                        "\t\tObjPosX=-6488\n" +
                        $"\t\tObjPosY={updatePackageNamePosY}\n" +
                        "\t\tDrawWidth=32\n" +
                        "\t\tDrawHeight=32\n" +
                        $"\t\tName=\"SeqVar_String_{i + 55007}\"\n" +
                        "\t\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                    "\tEnd Object\n";

                updatePackageNamePosY += 200;
            }







            updateMaterialCubesKismet +=
                    "\tDefaultViewX=2552\n" +
                    "\tDefaultViewY=3173\n" +
                    "\tDefaultViewZoom=0.400000\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=-4576\n" +
                    "\tObjPosY=-5616\n" +
                    "\tObjName=\"UpdateMaterialCubes\"\n" +
                    "\tDrawWidth=149\n" +
                    "\tDrawHeight=29\n" +
                    "\tName=\"UpdateMaterialCubes\"\n" +
                    "\tObjectArchetype=Sequence'Engine.Default__Sequence'\n" +
                "End Object\n";

            return updateMaterialCubesKismet;
        }
    }
}
