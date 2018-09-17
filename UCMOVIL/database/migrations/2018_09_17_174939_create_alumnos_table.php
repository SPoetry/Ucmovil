<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateAlumnosTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('alumnos', function (Blueprint $table) {
            $table->integer('id_alumno')->references('id')->on('users');
            $table->date('ano_ingreso');
            $table->string('nombre');
            $table->string('email', 190);
            $table->integer('ano_nacimiento');
            $table->string('telefono');
            $table->string('direccion');
            $table->integer('semestre_actual');
            $table->primary('id_alumno');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('alumnos');
    }
}
