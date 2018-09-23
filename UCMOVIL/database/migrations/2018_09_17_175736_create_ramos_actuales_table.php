<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateRamosActualesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('ramos_actuales', function (Blueprint $table) {
            $table->integer('id_asignatura')->references('id_asignatura')->on('asignaturas');
            $table->integer('id_alumno')->references('id_alumno')->on('alumnos');
            $table->float('nota');
            $table->integer('n_nota')->unique();
            $table->timestamps();
            $table->primary(['id_asignatura','id_alumno', 'n_nota']);
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('ramos_actuales');
    }
}
