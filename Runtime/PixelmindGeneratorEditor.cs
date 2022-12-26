using UnityEditor;
using UnityEngine;

namespace PixelmindImaginarium
{
#if UNITY_EDITOR
    [CustomEditor(typeof(PixelmindGenerator))]
    public class PixelmindGeneratorEditor : Editor
    {
        private SerializedProperty assignToMaterial;
        private SerializedProperty assignToSpriteRenderer;
        private SerializedProperty enableGUI;
        private SerializedProperty resultImage;
        private SerializedProperty apiKey;
        private SerializedProperty generatorFields;
        private SerializedProperty generators;
        private SerializedProperty generatorOptions;
        private SerializedProperty generatorOptionsIndex;
        private bool showApi = true;
        private bool showBasic = true;
        private bool showGenerators = true;
        private bool showOutput = true;
        private bool showGenerationButtons = true;
        
        void OnEnable()
        {
            assignToMaterial = serializedObject.FindProperty("assignToMaterial");
            assignToSpriteRenderer = serializedObject.FindProperty("assignToSpriteRenderer");
            enableGUI = serializedObject.FindProperty("enableGUI");
            apiKey = serializedObject.FindProperty("apiKey");
            resultImage = serializedObject.FindProperty("resultImage");
            generatorFields = serializedObject.FindProperty("generatorFields");
            generators = serializedObject.FindProperty("generators");
            generatorOptions = serializedObject.FindProperty("generatorOptions");
            generatorOptionsIndex = serializedObject.FindProperty("generatorOptionsIndex");
        }

        public override void OnInspectorGUI()
        {
            EditorUtility.SetDirty(target);

            serializedObject.Update();

            var pixelmindGenerator = (PixelmindGenerator)target;

            showApi = EditorGUILayout.Foldout(showApi, "Api");

            if (showApi)
            {
                EditorGUILayout.PropertyField(apiKey);
            }

            showBasic = EditorGUILayout.Foldout(showBasic, "Basic Settings");

            if (showBasic)
            {
                EditorGUILayout.PropertyField(enableGUI);
                EditorGUILayout.PropertyField(assignToSpriteRenderer);
                EditorGUILayout.PropertyField(assignToMaterial);
            }

            if (!EditorApplication.isPlayingOrWillChangePlaymode)
            {
                showGenerators = EditorGUILayout.Foldout(showGenerators, "Generators");

                if (showGenerators)
                {
                    if (GUILayout.Button("Get Generators"))
                    {
                        _ = pixelmindGenerator.GetGeneratorsWithFields();
                    }

                    // Iterate over generator fields and render them in the GUI
                    if (pixelmindGenerator.generatorFields.Count > 0)
                    {
                        RenderEditorFields(pixelmindGenerator);
                    }
                }

                showGenerationButtons = EditorGUILayout.Foldout(showGenerationButtons, "Generate");

                if (showGenerationButtons)
                {
                    if (pixelmindGenerator.PercentageCompleted() >= 0 && pixelmindGenerator.PercentageCompleted() < 100)
                    {
                        if (GUILayout.Button("Cancel (" + pixelmindGenerator.PercentageCompleted() + "%)"))
                        {
                            pixelmindGenerator.Cancel();
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Generate"))
                        {
                            _ = pixelmindGenerator.InitializeGeneration(
                                pixelmindGenerator.generatorFields,
                                pixelmindGenerator.generators[pixelmindGenerator.generatorOptionsIndex].generator
                            );
                        }
                    }
                }

                showOutput = EditorGUILayout.Foldout(showOutput, "Output");

                if (showOutput)
                {
                    EditorGUILayout.PropertyField(resultImage);
                    if (pixelmindGenerator.previewImage != null) GUILayout.Box(pixelmindGenerator.previewImage);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void RenderEditorFields(PixelmindGenerator pixelmindGenerator)
        {
            EditorGUI.BeginChangeCheck();

            pixelmindGenerator.generatorOptionsIndex = EditorGUILayout.Popup(
                pixelmindGenerator.generatorOptionsIndex,
                pixelmindGenerator.generatorOptions
            );

            if (EditorGUI.EndChangeCheck())
            {
                pixelmindGenerator.GetGeneratorFields(pixelmindGenerator.generatorOptionsIndex);
            }

            foreach (var field in pixelmindGenerator.generatorFields)
            {
                // Begin horizontal layout
                EditorGUILayout.BeginHorizontal();
                
                var required = field.required ? "*" : "";
                // Create label for field
                EditorGUILayout.LabelField(field.key + required);

                // Create text field for field value
                field.value = EditorGUILayout.TextField(field.value);

                // End horizontal layout
                EditorGUILayout.EndHorizontal();
            }
        }
    }
#endif
}