# Copilot Instructions for RimWorld Mod: I Can't Fix That

## Mod Overview and Purpose

"I Can't Fix That" is a RimWorld mod designed to add a layer of realism to the game by preventing pawns from repairing buildings, apparel, and weapons they do not know how to build. The idea is to create a logical consistency where tribal colonies can't effectively maintain advanced technology like solar panels or sniper rifles unless they have been researched. In this way, the mod aims to enhance the game's immersion and challenge.

## Key Features and Systems

- **Research-based Repair Restriction**: Prevents pawns from repairing items and structures that your colony has not researched.
- **Tech-level Based Mechanic**: Optionally block repairs based on the overall tech-level of your colony to further restrict maintenance capabilities.
- **Compatibility**: Works seamlessly with several popular RimWorld mods such as:
  - Fluffy Breakdowns and its update
  - MendAndRecycle
  - Repair Workbench, Misc. Weapon Repair
  - Repairable Gear, Repair Items
  - Vanilla Factions Expanded - Ancients Maintenance
- **Modular Integration**: Designed to be extensible so that additional repair mods can be supported without core changes.

## Coding Patterns and Conventions

- **C# Practices**: The mod is developed in C# using idiomatic practices such as static classes and methods for auxiliary functionality (_e.g._, utility methods).
- **Namespaces and Class Design**: Keeps a clear separation of functionalities within distinct classes and namespaces to maintain code modularity and readability.
- **Singleton Pattern**: Utilizes singleton-like constructs through internal static classes for settings and main mod configuration.

## XML Integration

- **DefInjection**: XML is used minimally, primarily for integrating new features smoothly into RimWorld's existing database via DefInjectors.
- **Configuration Files**: XML configuration files can manage specific mod settings and compatibility without altering core assemblies.

## Harmony Patching

- **Harmony**: Employed for altering existing game behavior without modifying original game files. Harmony patches are used for:
  - Modifying repair workgiver tasks to check against research prerequisites.
  - Integrating compatibility patches for third-party mods by intercepting or extending methods.
- **Patch Organization**: Patches are organized by feature and mod compatibility, maintaining a clean and understandable structure.

## Suggestions for Copilot

When contributing to or extending the "I Can't Fix That" mod, consider the following guidelines to make effective use of GitHub Copilot:

1. **Understanding RimWorld APIs**: Familiarity with RimWorld's APIs and how Harmony patches work is essential. Guide Copilot to make informed suggestions by commenting on the purpose of the patch before writing the code.
   
2. **Utilizing XML Defs**: When writing or modifying XML files, be specific in your comments about the data structure and desired behavior. This helps Copilot suggest accurate XML nodes and values.

3. **Code Consistency**: Maintain the existing naming conventions and coding patterns of the mod. Consistency helps Copilot suggest code snippets that integrate smoothly with existing structures.

4. **Feature Expansion**: For adding features, such as new compatibility with future repair mods, use descriptive comments outlining the feature's scope, which assists Copilot in providing contextual suggestions.

5. **Debugging Harmony Patches**: When encountering issues with Harmony patches, provide detailed comments describing the expected and actual behavior. This aids Copilot in offering debugging solutions or corrections.

By following these methodologies, Copilot can become a helpful tool in the development and enhancement of this mod, providing suggestions that are contextually aware and contribute positively to the codebase.
