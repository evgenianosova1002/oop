using System;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Базова ялинка
            ChristmasTree tree = new Yalynka();

            // Декоруємо прикрасами
            tree = new OrnamentsDecorator(tree, "toys, tinsel");

            // Додаємо гірлянду, яка може світитися
            GarlandDecorator garlandTree = new GarlandDecorator(tree);
            garlandTree.TurnOnLights(); // ялинка світиться

            garlandTree.Operation();

            // Wait for user
            Console.Read();
        }
    }

    // "Component"
    abstract class ChristmasTree
    {
        public abstract void Operation();
    }

    // "ConcreteComponent" ("Ялинка")
    class Yalynka : ChristmasTree
    {
        public override void Operation()
        {
            Console.WriteLine("Regular Christmas tree");
        }
    }

    // "Decorator"
    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        protected TreeDecorator(ChristmasTree tree)
        {
            this.tree = tree;
        }

        public override void Operation()
        {
            if (tree != null)
            {
                tree.Operation();
            }
        }
    }

    // "ConcreteDecoratorA" (прикраси)
    class OrnamentsDecorator : TreeDecorator
    {
        private string ornaments;

        public OrnamentsDecorator(ChristmasTree tree, string ornaments)
            : base(tree)
        {
            this.ornaments = ornaments;
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Ornaments: {0}", ornaments);
        }
    }

    // "ConcreteDecoratorB" (гірлянда)
    class GarlandDecorator : TreeDecorator
    {
        private bool lightsOn = false;

        public GarlandDecorator(ChristmasTree tree)
            : base(tree)
        {
        }

        public void TurnOnLights()
        {
            lightsOn = true;
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine(lightsOn
                ? "Garland is shining"
                : "Garland is not shining");
        }
    }
}
