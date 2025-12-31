# GitHub Copilot Instructions for `I Cant Fix That` Mod

This document provides guidance for using GitHub Copilot in the development of the "I Cant Fix That" mod for RimWorld. This mod is designed to enhance the immersive experience by altering how repair tasks are handled in the game based on the knowledge and tech levels of the colonists.

## Mod Overview and Purpose

The "I Cant Fix That" mod introduces a new gameplay rule where pawns in the colony are only able to repair items, buildings, apparel, and weapons that they are able to build (i.e., items they have researched or are at their tech level). This adds depth to the gameplay, preventing unrealistic repairs by colonies that have not developed the necessary skills or understanding.

### Key Features and Systems

- **Restricted Repair Abilities**: Limits the ability to repair items to those that have been researched or are at the colony's tech level.
- **Mod Compatibility**: Designed to work seamlessly with popular repair-related mods such as:
  - Fluffy Breakdowns
  - MendAndRecycle
  - Repair Workbench
  - Vanilla Factions Expanded - Ancients
- **Tech-level Settings**: Offers configuration options to block repairs based on the colony's technology level.

## Coding Patterns and Conventions

- **Class Naming**: Adheres to PascalCase for class names (e.g., `ICantFixThatMod`, `RepairUtility_PawnCanRepairEver`).
- **Method Structure**: Generally uses public static classes for functionality that doesn't require instantiation.
- **File Organization**: Each class is defined in a dedicated file to keep the project organized and maintainable.

## XML Integration

RimWorld modding relies heavily on XML files for defining various game objects and configurations. Ensure XML files are well-structured and valid to avoid errors. Typical usage includes defining:
- **ThingDefs** for custom items or behaviors.
- **WorkGivers** XML elements for repair jobs.

## Harmony Patching

Harmony is used to inject custom behavior into RimWorld's existing codebase:
- **Patch Methods**: Use Harmony to prefix, postfix, or transpile existing methods. Ensure that patched methods are targeted accurately by specifying the correct method signature.
- **Compatibility**: Use conditional patching for compatibility with other mods.

### Example Harmony Patch

csharp
[HarmonyPatch(typeof(RepairUtility))]
[HarmonyPatch("PawnCanRepairEver")]
public static class Patch_RepairUtility_PawnCanRepairEver
{
    static bool Prefix(Pawn pawn, Thing thing, ref bool __result)
    {
        // Custom logic to determine if the pawn can repair the thing
        // based on research or tech level
        __result = CustomRepairLogic(pawn, thing);
        return false; // Skip original method
    }
}


## Suggestions for Copilot

- **Contextual Suggestions**: When writing new code or patching existing methods, incorporate Copilot's suggestions for boilerplate and common patterns.
- **Customization and Flexibility**: Use Copilot's ability to adapt to code style and provide solutions tailored to specific scenarios, such as tech-level-specific behaviors.
- **Error Handling**: Ensure Copilot-generated code is reviewed for proper error handling, especially when interfacing with mod systems and Harmony patches.

By following these guidelines, contributors can effectively use GitHub Copilot to enhance the mod's functionality while maintaining compatibility and code quality.
