


namespace CLI {
    public class Program
    {
        public ExamGradeDAO egd;
        public KatedraDAO kd;
        public ProfessorDAO pd;
        public StudentDAO sd;
        public SubjectDAO sbjd;
        public ConsoleViewExamGrade cveg;
        public ConsoleViewKatedra cvek;
        public ConsoleViewProfessor cvep;
        public ConsoleViewStudent cves;
        public ConsoleViewSubject cvesbj;
        public ConsoleView consoleview;
        public Program()
        {
            egd = new ExamGradeDAO();
            kd = new KatedraDAO();
            pd = new ProfessorDAO();
            sd = new StudentDAO();
            sbjd = new SubjectDAO();

            cveg= new ConsoleViewExamGrade(egd,sd,sbjd);
            cvek = new ConsoleViewKatedra(kd, pd);
            cvep = new ConsoleViewProfessor(pd);
            cves = new ConsoleViewStudent(sd);
            cvesbj = new ConsoleViewSubject(sbjd, pd);
            consoleview = new ConsoleView(cveg, cvek, cvep, cves, cvesbj);
        }

        //ConsoleView c = new ConsoleView();
       public static void Main(string[] args)
        {
            Program p = new Program();
            p.consoleview.RunMenu();
        }
    }
}