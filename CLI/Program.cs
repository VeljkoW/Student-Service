


namespace CLI {
    public class Program
    {
        public AdressDAO ad;
        public ExamGradeDAO egd;
        public KatedraDAO kd;
        public ProfessorDAO pd;
        public StudentDAO sd;
        public SubjectDAO sbjd;
        public ConsoleViewAdress cva;
        public ConsoleViewExamGrade cveg;
        public ConsoleViewKatedra cvek;
        public ConsoleViewProfessor cvep;
        public ConsoleViewStudent cves;
        public ConsoleViewSubject cvesbj;
        public ConsoleView consoleview;
        public Program()
        {
            ad = new AdressDAO();
            egd = new ExamGradeDAO();
            kd = new KatedraDAO();
            pd = new ProfessorDAO();
            sd = new StudentDAO();
            sbjd = new SubjectDAO();

            cva = new ConsoleViewAdress(ad);
            cveg= new ConsoleViewExamGrade(egd,sd,sbjd);
            cvek = new ConsoleViewKatedra(kd, pd);
            cvep = new ConsoleViewProfessor(pd, ad);
            cves = new ConsoleViewStudent(sd, ad);
            cvesbj = new ConsoleViewSubject(sbjd, pd);
            consoleview = new ConsoleView(cva, cveg, cvek, cvep, cves, cvesbj);
        }

        //ConsoleView c = new ConsoleView();
       public static void Main(string[] args)
        {
            Program p = new Program();
            p.consoleview.RunMenu();
        }
    }
}