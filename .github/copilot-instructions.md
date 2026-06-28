# GitHub Copilot Instructions for "I Cant Fix That" RimWorld Modding Project

## Mod Overview and Purpose

**Mod Name**: I Cant Fix That  
**Author**: Mlie  
**PackageId**: Mlie.ICantFixThat  

"I Cant Fix That" is a mod for RimWorld that introduces realistic mechanics around the repair of buildings, apparel, and weapons. The purpose of the mod is to prevent pawns from repairing items they lack the knowledge to construct, ensuring that only researched technology can be properly maintained. This adds a layer of strategy regarding technology acquisition and maintenance within a colony, especially for tribal starts. It challenges the oddity of primitive societies capably maintaining advanced tech like solar panels and sniper rifles.

## Key Features and Systems

1. **Repair Restriction**: Pawns can only repair items if the technology is researched. Unresearched items can be used but not repaired.

2. **Compatibility**: The mod is compatible with popular repair mods:
   - Fluffy Breakdowns
   - MendAndRecycle
   - Repair Workbench
   - Misc. Weapon Repair
   - Repairable Gear
   - Others

   Support for additional mods can be added based on user feedback.

3. **Tech-Level Setting**: There is a configurable setting to restrict repairs based on the colony's tech level.

## Coding Patterns and Conventions

- **C# Naming Conventions**: Use PascalCase for class names and method names. Use camelCase for local variables and class members.

- **File Organization**: Each feature enhancement or compatibility patch is in a dedicated folder and C# file(s).

- **Method Signatures**: Reflectively synthesized method names and comments should clearly describe their purpose, preconditions, and postconditions.

## XML Integration

Currently, there are no XML definitions in this project, focusing entirely on C# and Harmony patches for integration.

## Harmony Patching

Harmony is used extensively to patch and override existing methods:
- **TargetMethod**: Identify the original method to patch.
- **Postfix**: Define additional logic to be executed after the original method.
- **Prefix**: Could be used for logic that needs to execute before the original method. (Currently no mention, but suggested if needed.)

Example:
csharp
[HarmonyPatch(typeof(TargetType))]
[HarmonyPatch(MethodType, MethodName = "TargetMethod")]
public class HarmonyPatchExample
{
    public static void Postfix(TargetParameters parameters)
    {
        // Additional logic after the method is executed
    }
}

Ensure all patches are checked for performance and potential conflicts with other mods.

## Suggestions for Copilot

1. **Code Completion**: Focus on generating method stubs consistently with the naming conventions and purpose brief provided above.

2. **Compatibility Layers**: Assist with writing additional compatibility layers for new mods as requested by users.

3. **Patching Examples**: Suggest relevant Harmony patch examples and comment them for clarity to maintain consistency in the project's methodology.

4. **Configuration Handling**: Assist in writing code that interfaces user configuration settings, particularly for managing tech-level restrictions.

5. **Documentation**: Encourage inline documentation in new or confusing sections of code to aid current and future developers in understanding the workflow.

---

End of Copilot instructions guide. Any changes or updates to the mod's features should be reflected here promptly.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).

