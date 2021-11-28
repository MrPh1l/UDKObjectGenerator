using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using UELib;

namespace AlexandriaLibraryGenerator.Classes
{
    internal class Level
    {
        private const string rlCookedPCConsoleDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\rocketleague\\TAGame\\CookedPCConsole";
        private const string LAYER = "MainLevel";

        public string MapData { get; private set; }
        public string Kismet { get; private set; }
        public List<Package> Packages { get; set; } = new List<Package>();

        public Level(List<string> packageNames)
        {
            var kismetLoc = new Vector2(6776, -2160);

            foreach (string packageName in packageNames)
            {
                if (!File.Exists($"{rlCookedPCConsoleDir}\\{packageName}.upk"))
                    return;

                var unrealPackage = UnrealLoader.LoadFullPackage($"{rlCookedPCConsoleDir}\\{packageName}.upk", FileAccess.Read);

                if (unrealPackage != null)
                {
                    if (kismetLoc.X > 8729)
                    {
                        kismetLoc.X = 6776;
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
                "Begin Object Class=SeqAct_SetMaterial Name=SeqAct_SetMaterial_0\n" +
                    "\tInputLinks(0)=(DrawY=-2666,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_Increment'SeqCond_Increment_2')),DrawY=-2666,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_13'),DrawX=7724,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(ExpectedType=Class'Engine.SeqVar_Object',LinkDesc=\"NewMaterial\",PropertyName=\"NewMaterial\",MinVars=0,DrawX=7802,OverrideDelta=76)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7686\n" +
                    "\tObjPosY=-2700\n" +
                    "\tDrawWidth=172\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_SetMaterial_0\"\n" +
                    "\tObjectArchetype=SeqAct_SetMaterial'Engine.Default__SeqAct_SetMaterial'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Object Name=SeqVar_Object_13\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7646\n" +
                    "\tObjPosY=-2548\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Object_13\"\n" +
                    "\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_2\n" +
                    "\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                    "\tFindVarName=\"CubeObjectList\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7430\n" +
                    "\tObjPosY=-2516\n" +
                    "\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_2\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AccessObjectList Name=SeqAct_AccessObjectList_2\n" +
                    "\tInputLinks(0)=(DrawY=-2703,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-2681,OverrideDelta=36)\n" +
                    "\tInputLinks(2)=(DrawY=-2659,OverrideDelta=58)\n" +
                    "\tInputLinks(3)=(DrawY=-2637,OverrideDelta=80)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetMaterial'SeqAct_SetMaterial_0')),DrawY=-2670,OverrideDelta=47)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_2'),DrawX=7460,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_1'),DrawX=7516,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_13'),DrawX=7574,OverrideDelta=128)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7422\n" +
                    "\tObjPosY=-2740\n" +
                    "\tDrawWidth=193\n" +
                    "\tDrawHeight=149\n" +
                    "\tName=\"SeqAct_AccessObjectList_2\"\n" +
                    "\tObjectArchetype=SeqAct_AccessObjectList'Engine.Default__SeqAct_AccessObjectList'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_3\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                    "\tFindVarName=\"CubeListCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7286\n" +
                    "\tObjPosY=-2612\n" +
                    "\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_3\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqCond_CompareInt Name=SeqCond_CompareInt_1\n" +
                    "\tInputLinks(0)=(DrawY=-2682,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(DrawY=-4490,bHidden=True,OverrideDelta=15)\n" +
                    "\tOutputLinks(1)=(DrawY=-4468,bHidden=True,OverrideDelta=37)\n" +
                    "\tOutputLinks(2)=(DrawY=-4446,bHidden=True,OverrideDelta=59)\n" +
                    "\tOutputLinks(3)=(Links=((LinkedOp=SeqAct_AccessObjectList'SeqAct_AccessObjectList_2',InputLinkIdx=3)),DrawY=-2682,OverrideDelta=11)\n" +
                    "\tOutputLinks(4)=(DrawY=-4402,bHidden=True,OverrideDelta=103)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_1'),DrawX=7287,OverrideDelta=29)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_3'),DrawX=7312,OverrideDelta=54)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7254\n" +
                    "\tObjPosY=-2716\n" +
                    "\tDrawWidth=91\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqCond_CompareInt_1\"\n" +
                    "\tObjectArchetype=SeqCond_CompareInt'Engine.Default__SeqCond_CompareInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_7\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                    "\tFindVarName=\"CubeListCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7270\n" +
                    "\tObjPosY=-3172\n" +
                    "\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_7\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqCond_CompareInt Name=SeqCond_CompareInt_2\n" +
                    "\tInputLinks(0)=(DrawY=-3234,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(DrawY=-4490,bHidden=True,OverrideDelta=15)\n" +
                    "\tOutputLinks(1)=(DrawY=-4468,bHidden=True,OverrideDelta=37)\n" +
                    "\tOutputLinks(2)=(DrawY=-4446,bHidden=True,OverrideDelta=59)\n" +
                    "\tOutputLinks(3)=(Links=((LinkedOp=SeqAct_AccessObjectList'SeqAct_AccessObjectList_0',InputLinkIdx=3)),DrawY=-3234,OverrideDelta=11)\n" +
                    "\tOutputLinks(4)=(DrawY=-4402,bHidden=True,OverrideDelta=103)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_1'),DrawX=7263,OverrideDelta=29)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_7'),DrawX=7288,OverrideDelta=54)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7230\n" +
                    "\tObjPosY=-3268\n" +
                    "\tDrawWidth=91\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqCond_CompareInt_2\"\n" +
                    "\tObjectArchetype=SeqCond_CompareInt'Engine.Default__SeqCond_CompareInt'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_1\n" +
                    "\tIntValue=-1\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7206\n" +
                    "\tObjPosY=-2932\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_1\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqCond_Increment Name=SeqCond_Increment_2\n" +
                    "\tInputLinks(0)=(DrawY=-3238,OverrideDelta=23)\n" +
                    "\tOutputLinks(0)=(DrawY=-4402,bHidden=True,OverrideDelta=15)\n" +
                    "\tOutputLinks(1)=(DrawY=-4380,bHidden=True,OverrideDelta=37)\n" +
                    "\tOutputLinks(2)=(DrawY=-4358,bHidden=True,OverrideDelta=59)\n" +
                    "\tOutputLinks(3)=(Links=((LinkedOp=SeqCond_CompareInt'SeqCond_CompareInt_2')),DrawY=-3248,OverrideDelta=13)\n" +
                    "\tOutputLinks(4)=(Links=((LinkedOp=SeqCond_CompareInt'SeqCond_CompareInt_1')),DrawY=-3228,OverrideDelta=33)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_1'),DrawX=7092,OverrideDelta=26)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_0'),DrawX=7117,OverrideDelta=51)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7062\n" +
                    "\tObjPosY=-3284\n" +
                    "\tDrawWidth=86\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqCond_Increment_2\"\n" +
                    "\tObjectArchetype=SeqCond_Increment'Engine.Default__SeqCond_Increment'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_0\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6902\n" +
                    "\tObjPosY=-3148\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_0\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ModifyObjectList Name=SeqAct_ModifyObjectList_1\n" +
                    "\tInputLinks(0)=(DrawY=-3255,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-3234,OverrideDelta=35)\n" +
                    "\tInputLinks(2)=(DrawY=-3213,OverrideDelta=56)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_Increment'SeqCond_Increment_2')),DrawY=-3234,OverrideDelta=35)\n" +
                    "\tVariableLinks(0)=(DrawX=6780,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_0'),DrawX=6840,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_0'),DrawX=6921,OverrideDelta=137)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6742\n" +
                    "\tObjPosY=-3292\n" +
                    "\tDrawWidth=237\n" +
                    "\tDrawHeight=125\n" +
                    "\tName=\"SeqAct_ModifyObjectList_1\"\n" +
                    "\tObjectArchetype=SeqAct_ModifyObjectList'Engine.Default__SeqAct_ModifyObjectList'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_4\n" +
                    "\tExpectedType=Class'Engine.SeqVar_Int'\n" +
                    "\tFindVarName=\"CubeListCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5660\n" +
                    "\tObjPosY=-2971\n" +
                    "\tObjColor=(B=255,G=255,R=0,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_4\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_1\n" +
                    "\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                    "\tFindVarName=\"CubeObjectList\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5534\n" +
                    "\tObjPosY=-2964\n" +
                    "\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_1\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ModifyObjectList Name=SeqAct_ModifyObjectList_2\n" +
                    "\tInputLinks(0)=(DrawY=-3087,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-3066,OverrideDelta=35)\n" +
                    "\tInputLinks(2)=(DrawY=-3045,OverrideDelta=56)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ConvertToString'SeqAct_ConvertToString_0')),DrawY=-3066,OverrideDelta=35)\n" +
                    "\tVariableLinks(0)=(DrawX=5524,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_1'),DrawX=5584,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_4'),DrawX=5665,OverrideDelta=137)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5486\n" +
                    "\tObjPosY=-3124\n" +
                    "\tDrawWidth=237\n" +
                    "\tDrawHeight=125\n" +
                    "\tName=\"SeqAct_ModifyObjectList_2\"\n" +
                    "\tObjectArchetype=SeqAct_ModifyObjectList'Engine.Default__SeqAct_ModifyObjectList'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_4\n" +
                    "\tSizeX=1830\n" +
                    "\tSizeY=556\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4406\n" +
                    "\tObjPosY=-2212\n" +
                    "\tObjComment=\"Cube Material name display\"\n" +
                    "\tDrawWidth=1830\n" +
                    "\tDrawHeight=556\n" +
                    "\tName=\"SequenceFrame_4\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_3\n" +
                    "\tSizeX=1953\n" +
                    "\tSizeY=1073\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6710\n" +
                    "\tObjPosY=-3460\n" +
                    "\tObjComment=\"Run through the material list and assign material to the corresponding cube\"\n" +
                    "\tDrawWidth=1953\n" +
                    "\tDrawHeight=1073\n" +
                    "\tName=\"SequenceFrame_3\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Object Name=SeqVar_Object_14\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=8302\n" +
                    "\tObjPosY=-2940\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Object_14\"\n" +
                    "\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AccessObjectList Name=SeqAct_AccessObjectList_1\n" +
                    "\tInputLinks(0)=(DrawY=-3367,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-3345,OverrideDelta=36)\n" +
                    "\tInputLinks(2)=(DrawY=-3323,OverrideDelta=58)\n" +
                    "\tInputLinks(3)=(DrawY=-3301,OverrideDelta=80)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_SetMaterial'SeqAct_SetMaterial_1')),DrawY=-3334,OverrideDelta=47)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_8'),DrawX=8100,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_1'),DrawX=8156,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_0'),DrawX=8214,OverrideDelta=128)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=8062\n" +
                    "\tObjPosY=-3404\n" +
                    "\tDrawWidth=193\n" +
                    "\tDrawHeight=149\n" +
                    "\tName=\"SeqAct_AccessObjectList_1\"\n" +
                    "\tObjectArchetype=SeqAct_AccessObjectList'Engine.Default__SeqAct_AccessObjectList'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_8\n" +
                    "\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                    "\tFindVarName=\"CubeObjectList\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=8086\n" +
                    "\tObjPosY=-3148\n" +
                    "\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_8\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Object Name=SeqVar_Object_0\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=8310\n" +
                    "\tObjPosY=-3100\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Object_0\"\n" +
                    "\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AccessObjectList Name=SeqAct_AccessObjectList_0\n" +
                    "\tInputLinks(0)=(DrawY=-3231,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-3209,OverrideDelta=36)\n" +
                    "\tInputLinks(2)=(DrawY=-3187,OverrideDelta=58)\n" +
                    "\tInputLinks(3)=(DrawY=-3165,OverrideDelta=80)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_AccessObjectList'SeqAct_AccessObjectList_1',InputLinkIdx=3)),DrawY=-3198,OverrideDelta=47)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_0'),DrawX=7476,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Int'SeqVar_Int_1'),DrawX=7532,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_14'),DrawX=7590,OverrideDelta=128)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=7438\n" +
                    "\tObjPosY=-3268\n" +
                    "\tDrawWidth=193\n" +
                    "\tDrawHeight=149\n" +
                    "\tName=\"SeqAct_AccessObjectList_0\"\n" +
                    "\tObjectArchetype=SeqAct_AccessObjectList'Engine.Default__SeqAct_AccessObjectList'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_0\n" +
                    "\tSizeX=527\n" +
                    "\tSizeY=356\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5966\n" +
                    "\tObjPosY=-3284\n" +
                    "\tObjComment=\"Display Cube object list amount (to delete I guess)\"\n" +
                    "\tDrawWidth=527\n" +
                    "\tDrawHeight=356\n" +
                    "\tName=\"SequenceFrame_0\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_String Name=SeqVar_String_4\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6110\n" +
                    "\tObjPosY=-3100\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_String_4\"\n" +
                    "\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ConvertToString Name=SeqAct_ConvertToString_0\n" +
                    "\tInputLinks(0)=(DrawY=-3146,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_DrawText'SeqAct_DrawText_2')),DrawY=-3146,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Named'SeqVar_Named_4'),DrawX=6083,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_String'SeqVar_String_4'),DrawX=6143,OverrideDelta=74)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6046\n" +
                    "\tObjPosY=-3180\n" +
                    "\tDrawWidth=136\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ConvertToString_0\"\n" +
                    "\tObjectArchetype=SeqAct_ConvertToString'Engine.Default__SeqAct_ConvertToString'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_DrawText Name=SeqAct_DrawText_2\n" +
                    "\tDrawTextInfo=(MessageText=\"Nbr of cube is \",MessageFontScale=(X=2.000000,Y=2.000000),MessageOffset=(X=0.000000,Y=-64.000000))\n" +
                    "\tInputLinks(0)=(DrawY=-3144,OverrideDelta=13)\n" +
                    "\tInputLinks(1)=(DrawY=-3124,OverrideDelta=33)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ModifyObjectList'SeqAct_ModifyObjectList_1',InputLinkIdx=1)),DrawY=-3134,OverrideDelta=23)\n" +
                    "\tVariableLinks(0)=(DrawX=6324,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_String'SeqVar_String_4'),bHidden=False,DrawX=6381,OverrideDelta=76)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6286\n" +
                    "\tObjPosY=-3180\n" +
                    "\tDrawWidth=131\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_DrawText_2\"\n" +
                    "\tObjectArchetype=SeqAct_DrawText'Engine.Default__SeqAct_DrawText'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_Delay Name=SeqAct_Delay_0\n" +
                    "\tInputLinks(0)=(DrawY=-3063,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-3042,OverrideDelta=35)\n" +
                    "\tInputLinks(2)=(DrawY=-3021,OverrideDelta=56)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_ModifyObjectList'SeqAct_ModifyObjectList_2',InputLinkIdx=1)),DrawY=-3058,OverrideDelta=19)\n" +
                    "\tOutputLinks(1)=(DrawY=-3026,OverrideDelta=51)\n" +
                    "\tVariableLinks(0)=(DrawX=5250,OverrideDelta=25)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5198\n" +
                    "\tObjPosY=-3100\n" +
                    "\tDrawWidth=106\n" +
                    "\tDrawHeight=109\n" +
                    "\tName=\"SeqAct_Delay_0\"\n" +
                    "\tObjectArchetype=SeqAct_Delay'Engine.Default__SeqAct_Delay'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_ObjectList Name=SeqVar_ObjectList_1\n" +
                    "\tVarName=\"CubeObjectList\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4558\n" +
                    "\tObjPosY=-3692\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_ObjectList_1\"\n" +
                    "\tObjectArchetype=SeqVar_ObjectList'Engine.Default__SeqVar_ObjectList'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_ActivateRemoteEvent Name=SeqAct_ActivateRemoteEvent_2\n" +
                    "\tEventName=\"InitObjectList\"\n" +
                    "\tInputLinks(0)=(DrawY=-3066,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Delay'SeqAct_Delay_0')),DrawY=-3066,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=4979,OverrideDelta=101)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4846\n" +
                    "\tObjPosY=-3100\n" +
                    "\tObjComment=\"Adds each cube to cube object list\"\n" +
                    "\tDrawWidth=267\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_ActivateRemoteEvent_2\"\n" +
                    "\tObjectArchetype=SeqAct_ActivateRemoteEvent'Engine.Default__SeqAct_ActivateRemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_Delay Name=SeqAct_Delay_1\n" +
                    "\tDuration=0.010000\n" +
                    "\tInputLinks(0)=(DrawY=-2151,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-2130,OverrideDelta=35)\n" +
                    "\tInputLinks(2)=(DrawY=-2109,OverrideDelta=56)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Gate'SeqAct_Gate_0')),DrawY=-2146,OverrideDelta=19)\n" +
                    "\tOutputLinks(1)=(DrawY=-2114,OverrideDelta=51)\n" +
                    "\tVariableLinks(0)=(DrawX=6154,OverrideDelta=25)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6102\n" +
                    "\tObjPosY=-2188\n" +
                    "\tDrawWidth=106\n" +
                    "\tDrawHeight=109\n" +
                    "\tName=\"SeqAct_Delay_1\"\n" +
                    "\tObjectArchetype=SeqAct_Delay'Engine.Default__SeqAct_Delay'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_Gate Name=SeqAct_Gate_0\n" +
                    "\tInputLinks(0)=(DrawY=-2039,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-2017,OverrideDelta=36)\n" +
                    "\tInputLinks(2)=(DrawY=-1995,OverrideDelta=58)\n" +
                    "\tInputLinks(3)=(DrawY=-1973,OverrideDelta=80)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_DrawText'SeqAct_DrawText_4')),DrawY=-2006,OverrideDelta=47)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5670\n" +
                    "\tObjPosY=-2076\n" +
                    "\tDrawWidth=82\n" +
                    "\tDrawHeight=117\n" +
                    "\tName=\"SeqAct_Gate_0\"\n" +
                    "\tObjectArchetype=SeqAct_Gate'Engine.Default__SeqAct_Gate'\n" +
                "End Object\n" +
                "Begin Object Class=SeqEvent_RemoteEvent Name=SeqEvent_RemoteEvent_0\n" +
                    "\tEventName=\"UntouchedBox\"\n" +
                    "\tMaxWidth=211\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Gate'SeqAct_Gate_0',InputLinkIdx=2)),DrawY=-1754,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(DrawX=4551,OverrideDelta=73)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4446\n" +
                    "\tObjPosY=-1820\n" +
                    "\tDrawWidth=125\n" +
                    "\tDrawHeight=128\n" +
                    "\tName=\"SeqEvent_RemoteEvent_0\"\n" +
                    "\tObjectArchetype=SeqEvent_RemoteEvent'Engine.Default__SeqEvent_RemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Object Name=SeqVar_Object_12\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4502\n" +
                    "\tObjPosY=-1980\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Object_12\"\n" +
                    "\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                "End Object\n" +
                "Begin Object Class=SeqEvent_RemoteEvent Name=SeqEvent_RemoteEvent_1\n" +
                    "\tEventName=\"TouchedBox\"\n" +
                    "\tMaxWidth=197\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_GetProperty'SeqAct_GetProperty_1')),DrawY=-2058,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_12'),DrawX=4536,OverrideDelta=66)\n" +
                    "\tObjInstanceVersion=2\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4438\n" +
                    "\tObjPosY=-2124\n" +
                    "\tDrawWidth=118\n" +
                    "\tDrawHeight=128\n" +
                    "\tName=\"SeqEvent_RemoteEvent_1\"\n" +
                    "\tObjectArchetype=SeqEvent_RemoteEvent'Engine.Default__SeqEvent_RemoteEvent'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_SetMaterial Name=SeqAct_SetMaterial_1\n" +
                    "\tInputLinks(0)=(DrawY=-3186,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqCond_Increment'SeqCond_Increment_2')),DrawY=-3186,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_0'),DrawX=8436,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(ExpectedType=Class'Engine.SeqVar_Object',LinkedVariables=(SeqVar_Object'SeqVar_Object_14'),LinkDesc=\"NewMaterial\",PropertyName=\"NewMaterial\",MinVars=0,DrawX=8514,OverrideDelta=76)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=8398\n" +
                    "\tObjPosY=-3220\n" +
                    "\tDrawWidth=172\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_SetMaterial_1\"\n" +
                    "\tObjectArchetype=SeqAct_SetMaterial'Engine.Default__SeqAct_SetMaterial'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_GetProperty Name=SeqAct_GetProperty_3\n" +
                    "\tPropertyName=\"Materials\"\n" +
                    "\tInputLinks(0)=(DrawY=-2058,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Gate'SeqAct_Gate_0'),(LinkedOp=SeqAct_Gate'SeqAct_Gate_0',InputLinkIdx=1)),DrawY=-2058,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_3'),DrawX=5212,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(DrawX=5272,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(DrawX=5319,OverrideDelta=136)\n" +
                    "\tVariableLinks(3)=(DrawX=5361,OverrideDelta=171)\n" +
                    "\tVariableLinks(4)=(LinkedVariables=(SeqVar_String'SeqVar_String_1'),DrawX=5413,OverrideDelta=220)\n" +
                    "\tVariableLinks(5)=(DrawX=5462,OverrideDelta=275)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5174\n" +
                    "\tObjPosY=-2092\n" +
                    "\tDrawWidth=318\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_GetProperty_3\"\n" +
                    "\tObjectArchetype=SeqAct_GetProperty'Engine.Default__SeqAct_GetProperty'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_GetProperty Name=SeqAct_GetProperty_1\n" +
                    "\tPropertyName=\"StaticMeshComponent\"\n" +
                    "\tInputLinks(0)=(DrawY=-2058,OverrideDelta=11)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_GetProperty'SeqAct_GetProperty_3')),DrawY=-2058,OverrideDelta=11)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_12'),DrawX=4828,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_Object'SeqVar_Object_3'),DrawX=4888,OverrideDelta=76)\n" +
                    "\tVariableLinks(2)=(DrawX=4935,OverrideDelta=136)\n" +
                    "\tVariableLinks(3)=(DrawX=4977,OverrideDelta=171)\n" +
                    "\tVariableLinks(4)=(DrawX=5029,OverrideDelta=220)\n" +
                    "\tVariableLinks(5)=(DrawX=5078,OverrideDelta=275)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4790\n" +
                    "\tObjPosY=-2092\n" +
                    "\tDrawWidth=318\n" +
                    "\tDrawHeight=61\n" +
                    "\tName=\"SeqAct_GetProperty_1\"\n" +
                    "\tObjectArchetype=SeqAct_GetProperty'Engine.Default__SeqAct_GetProperty'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Object Name=SeqVar_Object_3\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4854\n" +
                    "\tObjPosY=-2012\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Object_3\"\n" +
                    "\tObjectArchetype=SeqVar_Object'Engine.Default__SeqVar_Object'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_DrawText Name=SeqAct_DrawText_4\n" +
                    "\tDisplayTimeSeconds=0.010000\n" +
                    "\tDrawTextInfo=(MessageFontScale=(X=2.000000,Y=2.000000))\n" +
                    "\tInputLinks(0)=(DrawY=-2016,OverrideDelta=13)\n" +
                    "\tInputLinks(1)=(DrawY=-1996,OverrideDelta=33)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Delay'SeqAct_Delay_1')),DrawY=-2006,OverrideDelta=23)\n" +
                    "\tVariableLinks(0)=(DrawX=5948,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(LinkedVariables=(SeqVar_String'SeqVar_String_1'),bHidden=False,DrawX=6005,OverrideDelta=76)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5910\n" +
                    "\tObjPosY=-2052\n" +
                    "\tDrawWidth=131\n" +
                    "\tDrawHeight=85\n" +
                    "\tName=\"SeqAct_DrawText_4\"\n" +
                    "\tObjectArchetype=SeqAct_DrawText'Engine.Default__SeqAct_DrawText'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_String Name=SeqVar_String_1\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=5422\n" +
                    "\tObjPosY=-1804\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_String_1\"\n" +
                    "\tObjectArchetype=SeqVar_String'Engine.Default__SeqVar_String'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_2\n" +
                    "\tSizeX=1401\n" +
                    "\tSizeY=661\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4406\n" +
                    "\tObjPosY=-3508\n" +
                    "\tObjComment=\"Init\"\n" +
                    "\tDrawWidth=1401\n" +
                    "\tDrawHeight=661\n" +
                    "\tName=\"SequenceFrame_2\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Int Name=SeqVar_Int_10\n" +
                    "\tVarName=\"CubeListCount\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4670\n" +
                    "\tObjPosY=-3692\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Int_10\"\n" +
                    "\tObjectArchetype=SeqVar_Int'Engine.Default__SeqVar_Int'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_AddGameBall_TA Name=SeqAct_AddGameBall_TA_2\n" +
                    "\tInputLinks(0)=(DrawY=-3414,OverrideDelta=15)\n" +
                    "\tInputLinks(1)=(DrawY=-3392,OverrideDelta=37)\n" +
                    "\tInputLinks(2)=(DrawY=-3370,OverrideDelta=59)\n" +
                    "\tInputLinks(3)=(DrawY=-3348,OverrideDelta=81)\n" +
                    "\tInputLinks(4)=(DrawY=-3326,OverrideDelta=103)\n" +
                    "\tOutputLinks(0)=(DrawY=-3412,OverrideDelta=17)\n" +
                    "\tOutputLinks(1)=(DrawY=-3384,OverrideDelta=45)\n" +
                    "\tOutputLinks(2)=(DrawY=-3356,OverrideDelta=73)\n" +
                    "\tOutputLinks(3)=(DrawY=-3328,OverrideDelta=101)\n" +
                    "\tVariableLinks(0)=(LinkedVariables=(SeqVar_Player'SeqVar_Player_0'),DrawX=4926,OverrideDelta=16)\n" +
                    "\tVariableLinks(1)=(DrawX=5007,OverrideDelta=96)\n" +
                    "\tVariableLinks(2)=(DrawX=5086,OverrideDelta=178)\n" +
                    "\tVariableLinks(3)=(DrawX=5153,OverrideDelta=254)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4878\n" +
                    "\tObjPosY=-3452\n" +
                    "\tDrawWidth=313\n" +
                    "\tDrawHeight=173\n" +
                    "\tName=\"SeqAct_AddGameBall_TA_2\"\n" +
                    "\tObjectArchetype=SeqAct_AddGameBall_TA'tagame.Default__SeqAct_AddGameBall_TA'\n" +
                "End Object\n" +
                "Begin Object Class=SeqEvent_LevelLoaded Name=SeqEvent_LevelLoaded_1\n" +
                    "\tMaxWidth=136\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_Delay'SeqAct_Delay_2')),DrawY=-3375,OverrideDelta=14)\n" +
                    "\tOutputLinks(1)=(DrawY=-3354,OverrideDelta=35)\n" +
                    "\tOutputLinks(2)=(DrawY=-3333,OverrideDelta=56)\n" +
                    "\tObjInstanceVersion=3\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4438\n" +
                    "\tObjPosY=-3444\n" +
                    "\tDrawWidth=137\n" +
                    "\tName=\"SeqEvent_LevelLoaded_1\"\n" +
                    "\tObjectArchetype=SeqEvent_LevelLoaded'Engine.Default__SeqEvent_LevelLoaded'\n" +
                "End Object\n" +
                "Begin Object Class=SeqAct_Delay Name=SeqAct_Delay_2\n" +
                    "\tDuration=0.100000\n" +
                    "\tInputLinks(0)=(DrawY=-3375,OverrideDelta=14)\n" +
                    "\tInputLinks(1)=(DrawY=-3354,OverrideDelta=35)\n" +
                    "\tInputLinks(2)=(DrawY=-3333,OverrideDelta=56)\n" +
                    "\tOutputLinks(0)=(Links=((LinkedOp=SeqAct_AddGameBall_TA'SeqAct_AddGameBall_TA_2',InputLinkIdx=2),(LinkedOp=SeqAct_ActivateRemoteEvent'SeqAct_ActivateRemoteEvent_2')),DrawY=-3370,OverrideDelta=19)\n" +
                    "\tOutputLinks(1)=(DrawY=-3338,OverrideDelta=51)\n" +
                    "\tVariableLinks(0)=(DrawX=4730,OverrideDelta=25)\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4678\n" +
                    "\tObjPosY=-3412\n" +
                    "\tDrawWidth=106\n" +
                    "\tDrawHeight=109\n" +
                    "\tName=\"SeqAct_Delay_2\"\n" +
                    "\tObjectArchetype=SeqAct_Delay'Engine.Default__SeqAct_Delay'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Player Name=SeqVar_Player_0\n" +
                    "\tbAllPlayers=False\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=4894\n" +
                    "\tObjPosY=-3236\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Player_0\"\n" +
                    "\tObjectArchetype=SeqVar_Player'Engine.Default__SeqVar_Player'\n" +
                "End Object\n" +
                "Begin Object Class=SequenceFrame Name=SequenceFrame_1\n" +
                    "\tSizeX=2016\n" +
                    "\tSizeY=992\n" +
                    "\tbDrawBox=True\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6704\n" +
                    "\tObjPosY=-2224\n" +
                    "\tObjComment=\"Package materials\"\n" +
                    "\tDrawWidth=2016\n" +
                    "\tDrawHeight=992\n" +
                    "\tName=\"SequenceFrame_1\"\n" +
                    "\tObjectArchetype=SequenceFrame'Engine.Default__SequenceFrame'\n" +
                "End Object\n" +
                "Begin Object Class=SeqVar_Named Name=SeqVar_Named_0\n" +
                    "\tExpectedType=Class'Engine.SeqVar_ObjectList'\n" +
                    "\tFindVarName=\"mats_Park_P\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    "\tObjPosX=6800\n" +
                    "\tObjPosY=-3000\n" +
                    "\tObjColor=(B=102,G=0,R=102,A=255)\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_Named_0\"\n" +
                    "\tObjectArchetype=SeqVar_Named'Engine.Default__SeqVar_Named'\n" +
                "End Object\n";

            // Packages object list
            Packages.ForEach(p => Kismet += p.GetSerialized());

            Console.WriteLine("Level -> Kismet serialization done.");
        }
    }
}
