﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SELib;
using SELib.Utilities;

///
///   Program.cs (Unit tests)
///   Author: DTZxPorter
///   Written for the SE Format Project
///   Follows SEAnim specification v1.0.1
///   https://github.com/SE2Dev/SEAnim-Docs/blob/master/spec.md
///

namespace UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // SELib Unit Test
            Console.Title = "SELib Unit Tests";
            Console.WriteLine("SELib Unit Tests\n");

            Console.WriteLine("- SEAnims\n");

            #region SEAnim

            {
                // Log
                Console.Write("-- Test 1   ");
                // Make it
                var anim = new SEAnim();
                // Add some keys
                anim.AddTranslationKey("shoulder", 0, 0, 0, 0);
                anim.AddTranslationKey("shoulder", 5, 1, 1, 1);
                anim.AddTranslationKey("shoulder", 10, 10, 10, 10);
                anim.AddTranslationKey("shoulder", 30, 20, 20, 20);
                anim.AddTranslationKey("shoulder", 40, 30, 30, 30);

                // Save it
                anim.Write("test1.seanim");
                // Done
                Console.WriteLine("DONE!");
            }

            {
                // Log
                Console.Write("-- Test 2   ");
                // Make it
                var anim = new SEAnim();
                // Add some keys
                anim.AddTranslationKey("shoulder", 0, 0, 0, 0);
                anim.AddTranslationKey("shoulder", 5, 1, 1, 1);
                anim.AddTranslationKey("shoulder", 10, 10, 10, 10);
                anim.AddTranslationKey("shoulder", 30, 20, 20, 20);
                anim.AddTranslationKey("shoulder", 40, 30, 30, 30);
                // Add some scale
                anim.AddScaleKey("shoulder", 0, 1, 1, 1);
                anim.AddScaleKey("shoulder", 50, 3, 3, 3);

                // Save it
                anim.Write("test2.seanim");
                // Done
                Console.WriteLine("DONE!");
            }

            {
                // Log
                Console.Write("-- Test 3   ");
                // Make it
                var anim = new SEAnim();
                // Add some keys
                anim.AddTranslationKey("shoulder", 0, 0, 0, 0);
                anim.AddTranslationKey("shoulder", 5, 1, 1, 1);
                anim.AddTranslationKey("shoulder", 10, 10, 10, 10);
                anim.AddTranslationKey("shoulder", 30, 20, 20, 20);
                anim.AddTranslationKey("shoulder", 40, 30, 30, 30);
                // Add some scale
                anim.AddScaleKey("shoulder", 0, 1, 1, 1);
                anim.AddScaleKey("shoulder", 50, 3, 3, 3);
                // Add some note
                anim.AddNoteTrack("hello_world", 3);
                anim.AddNoteTrack("bye", 50);

                // Save it
                anim.Write("test3.seanim");
                // Done
                Console.WriteLine("DONE!");
            }

            {
                // Log
                Console.Write("-- Test 4   ");
                // Make it
                var anim = new SEAnim();
                // Add some keys
                anim.AddTranslationKey("shoulder", 0, 0, 0, 0);
                anim.AddTranslationKey("shoulder", 5, 1, 1, 1);
                anim.AddTranslationKey("shoulder", 10, 10, 10, 10);
                anim.AddTranslationKey("shoulder", 30, 20, 20, 20);
                anim.AddTranslationKey("shoulder", 40, 30, 30, 30);
                // Add some scale
                anim.AddScaleKey("shoulder", 0, 1, 1, 1);
                anim.AddScaleKey("shoulder", 50, 3, 3, 3);
                // Add some note
                anim.AddNoteTrack("hello_world", 3);
                anim.AddNoteTrack("bye", 50);

                // Save it (Really, we don't need doubles!!)
                anim.Write("test4.seanim", true);
                // Done
                Console.WriteLine("DONE!");
            }

            {
                // Log
                Console.Write("-- Test 5   ");
                // Make it
                var anim = new SEAnim();
                // Add some keys
                anim.AddTranslationKey("shoulder", 0, 0, 0, 0);
                anim.AddTranslationKey("shoulder", 5, 1, 1, 1);
                anim.AddTranslationKey("shoulder", 10, 10, 10, 10);
                anim.AddTranslationKey("shoulder", 30, 20, 20, 20);
                anim.AddTranslationKey("shoulder", 40, 30, 30, 30);
                // Add some scale
                anim.AddScaleKey("shoulder", 0, 1, 1, 1);
                anim.AddScaleKey("shoulder", 50, 3, 3, 3);
                // Add some rot
                anim.AddRotationKey("shoulder", 0, 0, 0, 0, 1);
                anim.AddRotationKey("shoulder", 50, 0.3, 0.2, 0.5, 1); // Random quat for test
                // Add some note
                anim.AddNoteTrack("hello_world", 3);
                anim.AddNoteTrack("bye", 50);

                // Save it
                anim.Write("test5.seanim");
                // Done
                Console.WriteLine("DONE!");
            }

            {
                // Log
                Console.Write("-- Test 6   ");
                // Read from test 5
                var anim = SEAnim.Read("test5.seanim");
                
                // Check data
                System.Diagnostics.Debug.Assert(anim.AnimationNotetracks.Count == 2);
                System.Diagnostics.Debug.Assert(anim.AnimationPositionKeys.Count == 1);
                System.Diagnostics.Debug.Assert(anim.AnimationRotationKeys.Count == 1);
                System.Diagnostics.Debug.Assert(anim.AnimationScaleKeys.Count == 1);
                System.Diagnostics.Debug.Assert(anim.BoneCount == 1);
                System.Diagnostics.Debug.Assert(anim.FrameCount == 51);
                System.Diagnostics.Debug.Assert(anim.FrameRate == 30.0);

                // Version
                System.Diagnostics.Debug.Assert(anim.APIVersion == "v1.0.1");

                // Check functions
                System.Diagnostics.Debug.Assert(anim.RenameBone("shoulder", "shoulder") == false);
                System.Diagnostics.Debug.Assert(anim.RenameBone("shoulder", "new_shoulder") == true);

                // Done
                Console.WriteLine("DONE!");
            }

            #endregion

            Console.WriteLine("\n- SEModels\n");

            #region SEModel

            {
                // Log
                Console.Write("-- Test 1   ");
                // Make it
                var model = new SEModel();
                // Add some bones
                model.AddBone("bone_0001", -1, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0002", 0, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0003", 0, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0004", 2, Vector3.Zero, Quaternion.Identity, new Vector3(22, 22, 22), Quaternion.Identity, Vector3.One);

                // Save it
                model.Write("test1.semodel");
                // Done
                Console.WriteLine("DONE!");
            }

            {
                // Log
                Console.Write("-- Test 2   ");
                // Make it
                var model = new SEModel();
                // Allow globals too
                model.ModelBoneSupport = ModelBoneSupportTypes.SupportsBoth;

                // Add some bones
                model.AddBone("bone_0001", -1, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0002", 0, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0003", 0, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0004", 2, Vector3.Zero, Quaternion.Identity, new Vector3(22, 22, 22), Quaternion.Identity, Vector3.One);

                // Save it
                model.Write("test2.semodel");
                // Done
                Console.WriteLine("DONE!");
            }

            {
                // Log
                Console.Write("-- Test 3   ");
                // Make it
                var model = new SEModel();

                // Add some bones
                model.AddBone("bone_0001", -1, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0002", 0, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0003", 0, Vector3.Zero, Quaternion.Identity, Vector3.Zero, Quaternion.Identity, Vector3.One);
                model.AddBone("bone_0004", 2, Vector3.Zero, Quaternion.Identity, new Vector3(22, 22, 22), Quaternion.Identity, Vector3.One);

                // Add a mesh
                var mesh = new SEModelMesh();

                // (32x32x32 cube) (Original was 64 but it's converted from inches to cm)

                // Add some data
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, -32.000015f, -32.000000f), VertexNormal = new Vector3(0.000000f, -0.988312f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 1.000000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, -32.000015f, 32.000000f), VertexNormal = new Vector3(0.000000f, -0.988312f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 0.750000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, -32.000015f, -32.000000f), VertexNormal = new Vector3(0.000000f, -0.988312f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 1.000000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, -32.000015f, 32.000000f), VertexNormal = new Vector3(0.000000f, -0.988312f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 0.750000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, -32.000015f, 32.000000f), VertexNormal = new Vector3(0.000000f, 0.000000f, 0.988312f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 0.750000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, 32.000000f, 32.000000f), VertexNormal = new Vector3(0.000000f, 0.000000f, 0.988312f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 0.500000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, -32.000015f, 32.000000f), VertexNormal = new Vector3(0.000000f, 0.000000f, 0.988312f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 0.750000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, 32.000000f, 32.000000f), VertexNormal = new Vector3(0.000000f, 0.000000f, 0.988312f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 0.500000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, 32.000000f, 32.000000f), VertexNormal = new Vector3(0.000000f, 0.988312f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 0.500000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, 32.000000f, -32.000000f), VertexNormal = new Vector3(0.000000f, 0.988312f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 0.250000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, 32.000000f, 32.000000f), VertexNormal = new Vector3(0.000000f, 0.988312f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 0.500000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, 32.000000f, -32.000000f), VertexNormal = new Vector3(0.000000f, 0.988312f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 0.250000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, 32.000000f, -32.000000f), VertexNormal = new Vector3(0.000000f, 0.000000f, -0.988312f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 0.250000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, -32.000015f, -32.000000f), VertexNormal = new Vector3(0.000000f, 0.000000f, -0.988312f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 0.000000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, 32.000000f, -32.000000f), VertexNormal = new Vector3(0.000000f, 0.000000f, -0.988312f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 0.250000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, -32.000015f, -32.000000f), VertexNormal = new Vector3(0.000000f, 0.000000f, -0.988312f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 0.000000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, -32.000015f, -32.000000f), VertexNormal = new Vector3(0.988312f, 0.000000f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 1.000000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, -32.000015f, 32.000000f), VertexNormal = new Vector3(0.988312f, 0.000000f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.625000f, 0.750000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, 32.000000f, -32.000000f), VertexNormal = new Vector3(0.988312f, 0.000000f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.875000f, 1.000000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(32.000015f, 32.000000f, 32.000000f), VertexNormal = new Vector3(0.988312f, 0.000000f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.875000f, 0.750000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, 32.000000f, -32.000000f), VertexNormal = new Vector3(-0.988312f, 0.000000f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.125000f, 1.000000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, 32.000000f, 32.000000f), VertexNormal = new Vector3(-0.988312f, 0.000000f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.125000f, 0.750000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, -32.000015f, -32.000000f), VertexNormal = new Vector3(-0.988312f, 0.000000f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 1.000000f) } } });
                mesh.AddVertex(new SEModelVertex() { Position = new Vector3(-32.000000f, -32.000015f, 32.000000f), VertexNormal = new Vector3(-0.988312f, 0.000000f, 0.000000f), UVSets = { new SEModelUVSet() { MaterialIndex = 0, UVCoord = new Vector2(0.375000f, 0.750000f) } } });
                mesh.AddFace(0, 1, 2);
                mesh.AddFace(1, 3, 2);
                mesh.AddFace(4, 5, 6);
                mesh.AddFace(5, 7, 6);
                mesh.AddFace(8, 9, 10);
                mesh.AddFace(9, 11, 10);
                mesh.AddFace(12, 13, 14);
                mesh.AddFace(13, 15, 14);
                mesh.AddFace(16, 17, 18);
                mesh.AddFace(17, 19, 18);
                mesh.AddFace(20, 21, 22);
                mesh.AddFace(21, 23, 22);

                // Add the mesh to the model
                model.AddMesh(mesh);



                // Save it
                model.Write("test3.semodel");
                // Done
                Console.WriteLine("DONE!");
            }

            #endregion

            // Pause
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
