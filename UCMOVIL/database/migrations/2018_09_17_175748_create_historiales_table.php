<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateHistorialesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('historiales', function (Blueprint $table) {
            $table->integer('id_asignatura')->references('id_asignatura')->on('asignaturas');
            $table->integer('id_alumno')->references('id_alumno')->on('alumnos');
            $table->string('estado');
            $table->integer('semestre');
            $table->integer('nota_final');
            $table->timestamps();
            $table->primary(['id_asignatura','id_alumno']);
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('historiales');
    }
}
