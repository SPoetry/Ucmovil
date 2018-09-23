<?php

use Illuminate\Database\Seeder;

class AsignaturaSeeder extends Seeder
{
    public function run()
    {
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-115',
        'nombre' => 'Algebra',
        'creditos' => '10'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-116',
        'nombre' => 'Calculo I',
        'creditos' => '10'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-117',
        'nombre' => 'introduccion a la computacion',
        'creditos' => '8'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-114',
        'nombre' => 'introduccion a la lingenieria',
        'creditos' => '8'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-126',
        'nombre' => 'Algebra lineal',
        'creditos' => '10',
        'pre-requisito' => 'ICI-115'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-123',
        'nombre' => 'Fisica I',
        'creditos' => '8'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-127',
        'nombre' => 'Calculo II',
        'creditos' => '10',
        'pre-requisito' => 'ICI-117'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-128',
        'nombre' => 'Lenguaje de programacion',
        'creditos' => '8',
        'pre-requisito' => 'ICI-117'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-118',
        'nombre' => 'Ingles I',
        'creditos' => '4',
        'pre-requisito' => 'ICI-118'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-217',
        'nombre' => 'Algebra abstracta',
        'creditos' => '8',
        'pre-requisito' => 'ICI-126'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-212',
        'nombre' => 'Fisica II',
        'creditos' => '9',
        'pre-requisito' => 'ICI-123'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-213',
        'nombre' => 'Estadistica y Probabilidad',
        'creditos' => '10',
        'pre-requisito' => 'ICI-127'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-214',
        'nombre' => 'Arquitectura de computadores I',
        'creditos' => '8',
        'pre-requisito' => 'ICI-128'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-215',
        'nombre' => 'Estrucutra de Datos',
        'creditos' => '9',
        'pre-requisito' => 'ICI-226'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-226',
        'nombre' => 'Tecnica de expresion oral y escrita',
        'creditos' => '5'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-221',
        'nombre' => 'Calculo III',
        'creditos' => '9',
        'pre-requisito' => 'ICI-127'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-222',
        'nombre' => 'Transmision de Datos',
        'creditos' => '8',
        'pre-requisito' => 'ICI-212'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-223',
        'nombre' => 'Arquitectura de Computadores II',
        'creditos' => '8',
        'pre-requisito' => 'ICI-214'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-224',
        'nombre' => 'Organizacion y Manejo de Archivos',
        'creditos' => '8',
        'pre-requisito' => 'ICI-215'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-225',
        'nombre' => 'Economia',
        'creditos' => '6'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-311',
        'nombre' => 'Ecuaciones Diferenciales',
        'creditos' => '9',
        'pre-requisito' => 'ICI-221'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-312',
        'nombre' => 'Sistemas Operativos',
        'creditos' => '10',
        'pre-requisito' => 'ICI-312'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-313',
        'nombre' => 'Modelamiento de Datos',
        'creditos' => '10',
        'pre-requisito' => 'ICI-224'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-314',
        'nombre' => 'Contabilidad y Costos',
        'creditos' => '10',
        'pre-requisito' => 'ICI-225'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'MFG-113',
        'nombre' => 'Introduccion a la Fe',
        'creditos' => '8'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-328',
        'nombre' => 'Calculo Numerico',
        'creditos' => '8',
        'pre-requisito' => 'ICI-311'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-329',
        'nombre' => 'Redes de Computacion',
        'creditos' => '8',
        'pre-requisito' => 'ICI-312'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-330',
        'nombre' => 'Sistemas de Informacion I',
        'creditos' => '8',
        'pre-requisito' => 'ICI-313'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-324',
        'nombre' => 'Bases de Datos',
        'creditos' => '8',
        'pre-requisito' => 'ICI-313'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-325',
        'nombre' => 'Sistemas de Gestion I',
        'creditos' => '8',
        'pre-requisito' => 'ICI-314'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'MFG-214',
        'nombre' => 'Etica Cristiana',
        'creditos' => '8',
        'pre-requisito' => 'MFG-113'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-411',
        'nombre' => 'Inferencia Estadistica',
        'creditos' => '9',
        'pre-requisito'=>'(4)'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-412',
        'nombre' => 'Mecanica',
        'creditos' => '9',
        'pre-requisito' => 'ICI-412'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-416',
        'nombre' => 'Sistemas de Informacion II',
        'creditos' => '9',
        'pre-requisito' => 'ICI-330'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-417',
        'nombre' => 'Ingenieria de Software',
        'creditos' => '8',
        'pre-requisito' => 'ICI-330'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-415',
        'nombre' => 'Legislacion Laboral',
        'creditos' => '6',
        'pre-requisito' => 'ICI-325'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-427',
        'nombre' => 'Matematica Discreta',
        'creditos' => '9',
        'pre-requisito' => 'ICI-427'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-422',
        'nombre' => 'Electromagnetismo',
        'creditos' => '9',
        'pre-requisito' => 'ICI-412'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-423',
        'nombre' => 'Investigacion de Operaciones',
        'creditos' => '8',
        'pre-requisito' => '(6)'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-424',
        'nombre' => 'Ingenieria de Software II',
        'creditos' => '9',
        'pre-requisito' => 'ICI-417'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-425',
        'nombre' => 'Ingenieria Economica',
        'creditos' => '6',
        'pre-requisito' => 'ICI-325'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-426',
        'nombre' => 'Recursos y Relacion Humana',
        'creditos' => '6',
        'pre-requisito' => 'ICI-415'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-511',
        'nombre' => 'Circuitos Digitales',
        'creditos' => '9',
        'pre-requisito' => 'ICI-422'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-512',
        'nombre' => 'Teoria Automata',
        'creditos' => '9',
        'pre-requisito' => 'ICI-427'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-513',
        'nombre' => 'Auditoria y Seguridad en Sistemas',
        'creditos' => '6',
        'pre-requisito' => 'ICI-513, (6)'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-514',
        'nombre' => 'Comunicacion Hombre-Maquina',
        'creditos' => '7',
        'pre-requisito' => 'ICI-424'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-515',
        'nombre' => 'Sistemas de Gestion II',
        'creditos' => '8',
        'pre-requisito' => 'ICI-425'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-516',
        'nombre' => 'Evaluacion de Proyectos',
        'creditos' => '8',
        'pre-requisito' => 'ICI-425'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-521',
        'nombre' => 'Metodos Formales',
        'creditos' => '10',
        'pre-requisito' => '(8)'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-522',
        'nombre' => 'Analisis de Algoritmos',
        'creditos' => '10',
        'pre-requisito' => 'ICI-512'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-524',
        'nombre' => 'Calidad y Produccion de Software',
        'creditos' => '10',
        'pre-requisito' => 'ICI-516'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-611',
        'nombre' => 'Sistemas Distribuidos',
        'creditos' => '10',
        'pre-requisito' => 'ICI-511, (6)'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-612',
        'nombre' => 'Inteligencia Artificial',
        'creditos' => '10',
        'pre-requisito' => 'ICI-522'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-613',
        'nombre' => 'Computacion Grafica',
        'creditos' => '8',
        'pre-requisito' => '(6)'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-621',
        'nombre' => 'Tesis',
        'creditos' => '30',
        'pre-requisito' => '(9)'
      ]);
      DB::table('asignaturas')->insert([
        'id_asignatura' => 'ICI-622',
        'nombre' => 'Practica Profesional',
        'creditos' => '20',
        'pre-requisito' => '(9)'
      ]);

    }
}
